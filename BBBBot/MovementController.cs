using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace MapleGatorBot
{
    public class MovementController
    {
        #region IPC Structure

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct IPCCommands
        {
            // Commands from C# to DLL
            public byte initialize;        // Use byte instead of bool
            public byte cleanup;
            public byte enableMovement;
            public byte disableMovement;
            public int setMovementX;
            public int setMovementY;
            public byte setMovementFlag;

            // Responses from DLL to C#
            public byte initialized;
            public byte hookActive;
            public byte movementEnabled;
        }

        #endregion

        #region P/Invoke Declarations

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr CreateFileMapping(IntPtr hFile, IntPtr lpFileMappingAttributes,
            uint flProtect, uint dwMaximumSizeHigh, uint dwMaximumSizeLow, string lpName);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr MapViewOfFile(IntPtr hFileMappingObject, uint dwDesiredAccess,
            uint dwFileOffsetHigh, uint dwFileOffsetLow, uint dwNumberOfBytesToMap);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool UnmapViewOfFile(IntPtr lpBaseAddress);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        private static extern IntPtr OpenFileMapping(uint dwDesiredAccess, bool bInheritHandle, string lpName);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern uint GetLastError();

        private const uint PAGE_READWRITE = 0x04;
        private const uint FILE_MAP_ALL_ACCESS = 0xF001F;
        private const uint ERROR_FILE_NOT_FOUND = 2;

        #endregion

        #region Private Members

        private IntPtr _sharedMemoryHandle;
        private IntPtr _sharedMemoryView;
        private IPCCommands _cachedCommands;
        private bool _connected = false;

        #endregion

        #region Public Methods

        /// <summary>
        /// Initialize connection to injected DLL via shared memory IPC
        /// </summary>
        public bool Initialize()
        {
            try
            {
                // Clean up any previous connection
                Cleanup();

                // Try to open existing shared memory created by injected DLL
                _sharedMemoryHandle = OpenFileMapping(FILE_MAP_ALL_ACCESS, false, "MapleGatorIPC");
                if (_sharedMemoryHandle == IntPtr.Zero)
                {
                    uint error = GetLastError();
                    if (error == ERROR_FILE_NOT_FOUND)
                    {
                        throw new Exception("Shared memory not found. Is backend.dll injected into MapleLegends?");
                    }
                    else
                    {
                        throw new Exception($"Failed to open shared memory. Error: {error}");
                    }
                }

                // Map the shared memory into our process
                _sharedMemoryView = MapViewOfFile(_sharedMemoryHandle, FILE_MAP_ALL_ACCESS, 0, 0,
                    (uint)Marshal.SizeOf<IPCCommands>());
                if (_sharedMemoryView == IntPtr.Zero)
                {
                    uint error = GetLastError();
                    CloseHandle(_sharedMemoryHandle);
                    _sharedMemoryHandle = IntPtr.Zero;
                    throw new Exception($"Failed to map shared memory view. Error: {error}");
                }

                _connected = true;

                // Clear any existing commands and send initialize
                var commands = new IPCCommands();
                commands.initialize = 1;
                commands.cleanup = 0;
                commands.enableMovement = 0;
                commands.disableMovement = 0;
                commands.setMovementX = 0;
                commands.setMovementY = 0;
                commands.setMovementFlag = 0;
                Marshal.StructureToPtr(commands, _sharedMemoryView, false);

                // Wait for response
                var timeout = DateTime.Now.AddMilliseconds(5000);
                bool initialized = false;

                while (DateTime.Now < timeout)
                {
                    Thread.Sleep(50);
                    commands = Marshal.PtrToStructure<IPCCommands>(_sharedMemoryView);
                    if (commands.initialized != 0)
                    {
                        _cachedCommands = commands;
                        initialized = true;
                        break;
                    }
                }

                if (!initialized)
                {
                    throw new Exception("DLL failed to initialize movement hooks within timeout.");
                }

                // Clear the initialize command flag after success
                commands.initialize = 0;
                Marshal.StructureToPtr(commands, _sharedMemoryView, false);

                return true;
            }
            catch (Exception ex)
            {
                Cleanup();
                throw new Exception($"MovementController initialization failed: {ex.Message}");
            }
        }

        // Helper method to show field offsets without unsafe code
        private void ShowFieldOffsets()
        {
            Console.WriteLine("C# Field offsets:");
            Console.WriteLine($"  initialize: {Marshal.OffsetOf<IPCCommands>("initialize")}");
            Console.WriteLine($"  cleanup: {Marshal.OffsetOf<IPCCommands>("cleanup")}");
            Console.WriteLine($"  enableMovement: {Marshal.OffsetOf<IPCCommands>("enableMovement")}");
            Console.WriteLine($"  disableMovement: {Marshal.OffsetOf<IPCCommands>("disableMovement")}");
            Console.WriteLine($"  setMovementX: {Marshal.OffsetOf<IPCCommands>("setMovementX")}");
            Console.WriteLine($"  setMovementY: {Marshal.OffsetOf<IPCCommands>("setMovementY")}");
            Console.WriteLine($"  setMovementFlag: {Marshal.OffsetOf<IPCCommands>("setMovementFlag")}");
            Console.WriteLine($"  initialized: {Marshal.OffsetOf<IPCCommands>("initialized")}");
            Console.WriteLine($"  hookActive: {Marshal.OffsetOf<IPCCommands>("hookActive")}");
            Console.WriteLine($"  movementEnabled: {Marshal.OffsetOf<IPCCommands>("movementEnabled")}");
        }

        // Add this helper method to show raw memory content
        private void ShowRawMemory(string label)
        {
            if (_sharedMemoryView == IntPtr.Zero) return;

            try
            {
                byte[] buffer = new byte[16];
                Marshal.Copy(_sharedMemoryView, buffer, 0, 16);

                Console.WriteLine($"Raw memory ({label}): {BitConverter.ToString(buffer)}");
                Console.WriteLine($"  Bytes 0-3: {buffer[0]} {buffer[1]} {buffer[2]} {buffer[3]} (commands)");
                Console.WriteLine($"  Bytes 4-7: {BitConverter.ToInt32(buffer, 4)} (setMovementX)");
                Console.WriteLine($"  Bytes 8-11: {BitConverter.ToInt32(buffer, 8)} (setMovementY)");
                Console.WriteLine($"  Bytes 12-15: {buffer[12]} {buffer[13]} {buffer[14]} {buffer[15]} (flag+responses)");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to read raw memory: {ex.Message}");
            }
        }

        /// <summary>
        /// Start movement control in the injected DLL
        /// </summary>
        public bool Start()
        {
            if (!_connected)
            {
                throw new InvalidOperationException("Not connected. Call Initialize() first.");
            }

            Console.WriteLine("Sending enable movement command...");
            ShowRawMemory("Before enable movement");

            // Create command structure
            var commands = new IPCCommands
            {
                initialize = 0,
                cleanup = 0,
                enableMovement = 1,  // Set this directly
                disableMovement = 0,
                setMovementX = 0,
                setMovementY = 0,
                setMovementFlag = 0,
                // Preserve response flags
                initialized = _cachedCommands.initialized,
                hookActive = _cachedCommands.hookActive,
                movementEnabled = _cachedCommands.movementEnabled
            };

            // Write to shared memory
            Marshal.StructureToPtr(commands, _sharedMemoryView, false);
            ShowRawMemory("After writing enable command");

            // Wait for response
            var timeout = DateTime.Now.AddMilliseconds(5000);
            while (DateTime.Now < timeout)
            {
                Thread.Sleep(50);
                var response = Marshal.PtrToStructure<IPCCommands>(_sharedMemoryView);
                Console.WriteLine($"Checking response - movementEnabled: {response.movementEnabled}");

                if (response.movementEnabled != 0)
                {
                    _cachedCommands = response;
                    Console.WriteLine("✓ Movement enabled successfully");
                    return true;
                }
            }

            ShowRawMemory("After timeout");
            Console.WriteLine("✗ Failed to enable movement - timeout");
            return false;
        }

        /// <summary>
        /// Stop movement control in the injected DLL
        /// </summary>
        public void Stop()
        {
            if (!_connected) return;

            // Stop current movement first
            SetMovement(0, 0);

            // Create command structure
            var commands = new IPCCommands
            {
                initialize = 0,
                cleanup = 0,
                enableMovement = 0,
                disableMovement = 1,  // Set this directly
                setMovementX = 0,
                setMovementY = 0,
                setMovementFlag = 0,
                // Preserve response flags
                initialized = _cachedCommands.initialized,
                hookActive = _cachedCommands.hookActive,
                movementEnabled = _cachedCommands.movementEnabled
            };

            // Write to shared memory
            Marshal.StructureToPtr(commands, _sharedMemoryView, false);

            // Wait for response
            var timeout = DateTime.Now.AddMilliseconds(5000);
            while (DateTime.Now < timeout)
            {
                Thread.Sleep(50);
                var response = Marshal.PtrToStructure<IPCCommands>(_sharedMemoryView);
                if (response.movementEnabled == 0)
                {
                    _cachedCommands = response;
                    break;
                }
            }
        }

        /// <summary>
        /// Set movement direction in the injected DLL
        /// </summary>
        /// <param name="leftRight">-1=left, 0=neutral, 1=right</param>
        /// <param name="upDown">-1=up, 0=neutral, 1=down</param>
        public void SetMovement(int leftRight, int upDown)
        {
            if (!_connected) return;

            SendMovementCommand(leftRight, upDown);
        }

        /// <summary>
        /// Check if hooks are active in the injected DLL
        /// </summary>
        public bool IsHookActive()
        {
            if (!_connected) return false;

            ReadCurrentState();
            return _cachedCommands.hookActive != 0;
        }

        /// <summary>
        /// Check if movement is enabled in the injected DLL
        /// </summary>
        public bool IsMovementEnabled()
        {
            if (!_connected) return false;

            ReadCurrentState();
            return _cachedCommands.movementEnabled != 0;
        }

        /// <summary>
        /// Get current connection status
        /// </summary>
        public bool IsConnected()
        {
            return _connected && _sharedMemoryView != IntPtr.Zero;
        }

        /// <summary>
        /// Cleanup and disconnect from injected DLL
        /// </summary>
        public void Cleanup()
        {
            try
            {
                if (_connected && _sharedMemoryView != IntPtr.Zero)
                {
                    // Send cleanup command to DLL
                    var commands = new IPCCommands
                    {
                        initialize = 0,
                        cleanup = 1,  // Set cleanup command
                        enableMovement = 0,
                        disableMovement = 0,
                        setMovementX = 0,
                        setMovementY = 0,
                        setMovementFlag = 0,
                        // Clear response flags too
                        initialized = 0,
                        hookActive = 0,
                        movementEnabled = 0
                    };

                    Marshal.StructureToPtr(commands, _sharedMemoryView, false);

                    // Give DLL time to process cleanup
                    Thread.Sleep(100);
                }

                if (_sharedMemoryView != IntPtr.Zero)
                {
                    UnmapViewOfFile(_sharedMemoryView);
                    _sharedMemoryView = IntPtr.Zero;
                }

                if (_sharedMemoryHandle != IntPtr.Zero)
                {
                    CloseHandle(_sharedMemoryHandle);
                    _sharedMemoryHandle = IntPtr.Zero;
                }

                _connected = false;
            }
            catch
            {
                // Ignore cleanup errors
            }
        }

        #endregion

        #region Convenience Movement Methods

        /// <summary>
        /// Move character left
        /// </summary>
        public void MoveLeft() => SetMovement(-1, 0);

        /// <summary>
        /// Move character right
        /// </summary>
        public void MoveRight() => SetMovement(1, 0);

        /// <summary>
        /// Move character up
        /// </summary>
        public void MoveUp() => SetMovement(0, -1);

        /// <summary>
        /// Move character down
        /// </summary>
        public void MoveDown() => SetMovement(0, 1);

        /// <summary>
        /// Stop all movement
        /// </summary>
        public void StopMove() => SetMovement(0, 0);

        /// <summary>
        /// Move diagonally up-left
        /// </summary>
        public void MoveUpLeft() => SetMovement(-1, -1);

        /// <summary>
        /// Move diagonally up-right
        /// </summary>
        public void MoveUpRight() => SetMovement(1, -1);

        /// <summary>
        /// Move diagonally down-left
        /// </summary>
        public void MoveDownLeft() => SetMovement(-1, 1);

        /// <summary>
        /// Move diagonally down-right
        /// </summary>
        public void MoveDownRight() => SetMovement(1, 1);

        #endregion

        #region Private IPC Methods

        /// <summary>
        /// Send a command to the DLL and wait for response
        /// </summary>
        private bool SendCommand(Action<IPCCommands> setCommand, Func<IPCCommands, bool> checkResponse, int timeoutMs = 5000)
        {
            if (_sharedMemoryView == IntPtr.Zero)
                return false;

            try
            {
                // Create new command structure with all flags cleared
                var commands = new IPCCommands
                {
                    initialize = 0,
                    cleanup = 0,
                    enableMovement = 0,
                    disableMovement = 0,
                    setMovementX = 0,
                    setMovementY = 0,
                    setMovementFlag = 0,
                    // Preserve response flags from current state
                    initialized = _cachedCommands.initialized,
                    hookActive = _cachedCommands.hookActive,
                    movementEnabled = _cachedCommands.movementEnabled
                };

                // Set the specific command
                setCommand(commands);

                // Write to shared memory
                Marshal.StructureToPtr(commands, _sharedMemoryView, false);

                // Wait for response
                var timeout = DateTime.Now.AddMilliseconds(timeoutMs);
                while (DateTime.Now < timeout)
                {
                    Thread.Sleep(50);
                    var response = Marshal.PtrToStructure<IPCCommands>(_sharedMemoryView);
                    if (checkResponse(response))
                    {
                        _cachedCommands = response;
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SendCommand exception: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Send movement command (no response needed, fire-and-forget)
        /// </summary>
        private void SendMovementCommand(int x, int y)
        {
            if (_sharedMemoryView == IntPtr.Zero)
                return;

            try
            {
                var commands = Marshal.PtrToStructure<IPCCommands>(_sharedMemoryView);
                commands.setMovementX = x;
                commands.setMovementY = y;
                commands.setMovementFlag = 1;  // true
                Marshal.StructureToPtr(commands, _sharedMemoryView, false);
            }
            catch
            {
                // Ignore movement command errors (fire-and-forget)
            }
        }

        /// <summary>
        /// Read current state from DLL
        /// </summary>
        private void ReadCurrentState()
        {
            if (_sharedMemoryView != IntPtr.Zero)
            {
                try
                {
                    _cachedCommands = Marshal.PtrToStructure<IPCCommands>(_sharedMemoryView);
                }
                catch
                {
                    // Use cached data if read fails
                }
            }
        }

        #endregion

        #region IDisposable Pattern

        /// <summary>
        /// Finalizer to ensure cleanup
        /// </summary>
        ~MovementController()
        {
            Cleanup();
        }

        #endregion
    }
}