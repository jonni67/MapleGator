using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;

namespace MapleGatorBot
{
    public partial class MapleGator : Form
    {
		#region DLL Imports
		// DLL Injection P/Invoke Declarations
		[DllImport("kernel32.dll", SetLastError = true)]
		static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

		[DllImport("kernel32.dll", SetLastError = true)]
		static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress,
			uint dwSize, uint flAllocationType, uint flProtect);

		[DllImport("kernel32.dll", SetLastError = true)]
		static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress,
			byte[] lpBuffer, uint nSize, out IntPtr lpNumberOfBytesWritten);

		[DllImport("kernel32.dll", SetLastError = true)]
		static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

		[DllImport("kernel32.dll", SetLastError = true)]
		static extern IntPtr GetModuleHandle(string lpModuleName);

		[DllImport("kernel32.dll", SetLastError = true)]
		static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes,
			uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

		[DllImport("kernel32.dll", SetLastError = true)]
		static extern bool CloseHandle(IntPtr hObject);

		#endregion

		#region Public Fields

		public bool AutoLoginEnabled
		{
			get { return _autoLoginEnabled; }
			set { _autoLoginEnabled = value; }
		}

		#endregion

		#region Private Members

		// memory hex //
		const int PROCESS_ALL_ACCESS = 0x1F0FFF;
		const uint MEM_COMMIT = 0x1000;
		const uint MEM_RESERVE = 0x2000;
		const uint PAGE_READWRITE = 0x04;
		
		// components //
		Dictionary<ComponentIDs, Form> _components;

		Primary _primary;
		Pathfinding _pathfinding;
		MovementController _moveController;
		Form _shownComponent;

		// settings //
		int stateDelayMs = 50;

		// states //
		BotStates _state;
		bool _running = false;
		bool _hooked = false;
		bool _autoLoginEnabled = false;

		#endregion

		#region Public Methods

		// constructor //
		public MapleGator()
		{
			InitializeComponent();

			if (Styling.ACRYLIC_STYLING)
			{
				Styling.SetAcrylicStyling(Handle);
			}

			SetStyling();
		}

        /// <summary>
        /// Hooks to process writing bytes.
        /// </summary>
        /// <param name="process">The full name of the process.</param>
        public void HookProcess(string process)
        {
            // Extract PID
            int pidStart = process.IndexOf("PID: ") + 5;
            int pidEnd = process.IndexOf(")", pidStart);
            string pidStr = process.Substring(pidStart, pidEnd - pidStart);
            if (!int.TryParse(pidStr, out int pid))
            {
                MessageBox.Show("Invalid PID.");
                return;
            }

            string dllPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "backend.dll");
            if (!File.Exists(dllPath))
            {
                MessageBox.Show("backend.dll not found in application directory.");
                return;
            }

            IntPtr hProcess = OpenProcess(PROCESS_ALL_ACCESS, false, pid);
            if (hProcess == IntPtr.Zero)
            {
                MessageBox.Show("Failed to open target process.");
                return;
            }

            try
            {
                IntPtr allocMemAddress = VirtualAllocEx(hProcess, IntPtr.Zero,
                    (uint)((dllPath.Length + 1) * Marshal.SizeOf(typeof(char))),
                    MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);

                if (allocMemAddress == IntPtr.Zero)
                {
                    MessageBox.Show("Failed to allocate memory in target process.");
                    return;
                }

                byte[] dllBytes = Encoding.ASCII.GetBytes(dllPath + "\0");
                if (!WriteProcessMemory(hProcess, allocMemAddress, dllBytes, (uint)dllBytes.Length, out _))
                {
                    MessageBox.Show("Failed to write DLL path to target process.");
                    return;
                }

                IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
                if (loadLibraryAddr == IntPtr.Zero)
                {
                    MessageBox.Show("Failed to get address of LoadLibraryA.");
                    return;
                }

                IntPtr remoteThread = CreateRemoteThread(hProcess, IntPtr.Zero, 0, loadLibraryAddr,
                    allocMemAddress, 0, IntPtr.Zero);

                if (remoteThread == IntPtr.Zero)
                {
                    MessageBox.Show("Failed to create remote thread.");
                    return;
                }

                // Wait for the remote thread to complete
                uint waitResult = WaitForSingleObject(remoteThread, 10000); // 10 second timeout
                if (waitResult != WAIT_OBJECT_0)
                {
                    MessageBox.Show("DLL injection thread did not complete in time.");
                    CloseHandle(remoteThread);
                    return;
                }

                // Get the exit code to verify LoadLibrary succeeded
                if (GetExitCodeThread(remoteThread, out uint exitCode))
                {
                    if (exitCode == 0) // LoadLibrary returns NULL on failure
                    {
                        MessageBox.Show("LoadLibrary failed in target process.");
                        CloseHandle(remoteThread);
                        return;
                    }
                }

                CloseHandle(remoteThread);
                _hooked = true;
                MessageBox.Show("DLL injected successfully! Movement will be tested when bot runs.");

                // Wait for DLL to initialize its shared memory
                Thread.Sleep(1000);

                // Don't initialize or test here - let the bot state machine handle it
            }
            finally
            {
                CloseHandle(hProcess);
            }
        }

        // Add these P/Invoke declarations if you don't have them:
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern uint WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool GetExitCodeThread(IntPtr hThread, out uint lpExitCode);

        private const uint WAIT_OBJECT_0 = 0x00000000;
        private const uint WAIT_TIMEOUT = 0x00000102;

        // **NEW METHOD**: Initialize with retry logic
        private bool InitializeWithRetry(int maxAttempts = 5, int delayMs = 1000)
        {
            for (int attempt = 1; attempt <= maxAttempts; attempt++)
            {
                try
                {
                    Console.WriteLine($"Initialization attempt {attempt}/{maxAttempts}...");

                    if (_moveController.Initialize())
                    {
                        Console.WriteLine("✓ MovementController initialized successfully");
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Attempt {attempt} failed: {ex.Message}");

                    if (attempt < maxAttempts)
                    {
                        Console.WriteLine($"Waiting {delayMs}ms before retry...");
                        Thread.Sleep(delayMs);
                    }
                }
            }

            return false;
        }

        #endregion

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _running = false;

            if (_moveController != null && _moveController.IsConnected())
            {
                _moveController.Stop();
                _moveController.Cleanup();
            }

            base.OnFormClosing(e);
        }


        #region Private Methods

        /// <summary>
        /// Loads forms as indentifiable components.
        /// </summary>
        private void LoadComponents()
		{
			_components = new Dictionary<ComponentIDs, Form>();

			// create form components
			_primary = new Primary(this);
			_pathfinding = new Pathfinding(this);
			_moveController = new MovementController();

			// add components to dict
			_components.Add(ComponentIDs.Primary, _primary);
			_components.Add(ComponentIDs.Pathfinding, _pathfinding);

			// set all components in dict
			foreach (ComponentIDs id in Enum.GetValues(typeof(ComponentIDs)))
			{
				if (!_components.ContainsKey(id) || _components[id] == null)
					continue;
				_components[id].MdiParent = this;
			}
			
			_pathfinding.Show();
			_primary.Show(); // primary is first component shown on load
			_shownComponent = _components[ComponentIDs.Primary];
			Console.WriteLine("Loaded Form Components");
		}

		/// <summary>
		/// Switches to a new visible form component.
		/// </summary>
		private void SwitchComponent(ComponentIDs id)
		{
			if (_shownComponent.Name == _components[id].Name)
				return;

			SuspendLayout();
			Styling.ShowFormWithoutFlicker(_components[id]);
			Styling.HideFormWithoutFlicker(_shownComponent);
			ResumeLayout();
			_shownComponent = _components[id];
		}

		private void SetStyling()
		{
			BackColor = Color.Black;
			menuStrip.BackColor = Color.FromArgb(Styling.PANEL_ALPHA, Styling.PANEL_COLOR);
		}

		private async void RunBot()
		{
			while (_running)
			{
				switch (_state)
				{
					case BotStates.Idle:
						_primary.StatusLabel.Text = "Idle ...";
						await DoIdle();
						break;

					case BotStates.Waiting:
						_primary.StatusLabel.Text = "Waiting ...";
						await DoWait();
						_state = BotStates.Moving;
						break;

					case BotStates.Moving:
						_primary.StatusLabel.Text = "Moving ...";
						await DelayWithProgress(1000);
						await DoMove();
						_state = BotStates.Waiting;
						break;

					case BotStates.Attacking:
						_primary.StatusLabel.Text = "Attacking ...";
						await DoAttack();
						_state = BotStates.Waiting;
						break;
				}

				await Task.Delay(stateDelayMs);
			}
		}

		private async Task DelayWithProgress(int totalDelayMs)
		{
			Stopwatch sw = Stopwatch.StartNew();

			while (sw.ElapsedMilliseconds < totalDelayMs)
			{
				float remaining = totalDelayMs - (float)(sw.ElapsedMilliseconds);
				string rs = (remaining / 1000).ToString("0.00");
				_primary.TimerLabel.Text = $"{rs} Sec Left";
				await Task.Delay(1); // Check every 100ms
			}
		}

		private async Task DoIdle()
		{
			if(!_hooked)
			{
				await DelayWithProgress(1000);
				_primary.StatusLabel.Text = "No Hook";
				await DelayWithProgress(1000);
				_state = BotStates.Idle;
				return;
			}

			_state = BotStates.Waiting;
		}

		private async Task DoWait()
		{
			int delayMs = 800;
			await DelayWithProgress(delayMs);
		}

        private async Task DoMove()
        {
            try
            {
                // Check if we're connected and initialized
                if (!_moveController.IsConnected())
                {
                    Console.WriteLine("Movement controller not connected. Reinitializing...");

                    if (!_moveController.Initialize())
                    {
                        Console.WriteLine("✗ Failed to initialize movement controller");
                        return;
                    }
                    Console.WriteLine("✓ Movement controller initialized");
                }

                // Check if hooks are active
                if (!_moveController.IsHookActive())
                {
                    Console.WriteLine("✗ Hooks not active");
                    return;
                }

                // Enable movement if not already enabled
                if (!_moveController.IsMovementEnabled())
                {
                    Console.WriteLine("Enabling movement...");
                    if (!_moveController.Start())
                    {
                        Console.WriteLine("✗ Failed to enable movement");
                        return;
                    }
                    Console.WriteLine("✓ Movement enabled");
                }

                // Perform movement test sequence
                Console.WriteLine("=== Starting Movement Test Sequence ===");

                // 1. Basic directional movement
                Console.WriteLine("Test 1: Basic Directions");

                _moveController.MoveRight();
                Console.WriteLine("→ Moving right");
                await DelayWithProgress(1000);

                _moveController.MoveLeft();
                Console.WriteLine("← Moving left");
                await DelayWithProgress(1000);

                _moveController.MoveUp();
                Console.WriteLine("↑ Moving up");
                await DelayWithProgress(1000);

                _moveController.MoveDown();
                Console.WriteLine("↓ Moving down");
                await DelayWithProgress(1000);

                _moveController.StopMove();
                Console.WriteLine("✓ Stopped");
                await DelayWithProgress(500);

                // 2. Diagonal movement (key combos)
                Console.WriteLine("\nTest 2: Diagonal Movement (Key Combos)");

                _moveController.MoveUpRight();
                Console.WriteLine("↗ Moving up-right");
                await DelayWithProgress(1000);

                _moveController.MoveUpLeft();
                Console.WriteLine("↖ Moving up-left");
                await DelayWithProgress(1000);

                _moveController.MoveDownRight();
                Console.WriteLine("↘ Moving down-right");
                await DelayWithProgress(1000);

                _moveController.MoveDownLeft();
                Console.WriteLine("↙ Moving down-left");
                await DelayWithProgress(1000);

                _moveController.StopMove();
                Console.WriteLine("✓ Stopped");
                await DelayWithProgress(500);

                // 3. Rapid direction changes
                Console.WriteLine("\nTest 3: Rapid Direction Changes");

                for (int i = 0; i < 5; i++)
                {
                    _moveController.MoveRight();
                    await Task.Delay(200);
                    _moveController.MoveLeft();
                    await Task.Delay(200);
                }

                _moveController.StopMove();
                Console.WriteLine("✓ Rapid changes complete");
                await DelayWithProgress(500);

                // 4. Complex movement pattern (simulate real gameplay)
                Console.WriteLine("\nTest 4: Complex Movement Pattern");

                // Move right while jumping (up+right)
                _moveController.MoveUpRight();
                Console.WriteLine("Jump right");
                await Task.Delay(300);

                // Land and continue right
                _moveController.MoveRight();
                Console.WriteLine("Continue right");
                await Task.Delay(500);

                // Jump left
                _moveController.MoveUpLeft();
                Console.WriteLine("Jump left");
                await Task.Delay(300);

                // Drop down
                _moveController.MoveDown();
                Console.WriteLine("Drop down");
                await Task.Delay(500);

                _moveController.StopMove();
                Console.WriteLine("✓ Complex pattern complete");

                Console.WriteLine("\n=== Movement Test Sequence Complete ===");

                // Keep movement enabled but stop moving
                _moveController.StopMove();

                // Note: We're NOT calling Cleanup() here anymore
                // The movement controller stays connected for the next cycle
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Error during movement test: {ex.Message}");
                _moveController.StopMove();
            }
        }

        private async Task DoAttack()
		{
			int delayMs = 800;
			await DelayWithProgress(delayMs);
		}

		#endregion

		#region Callbacks

		private void MapleGator_Load(object sender, EventArgs e)
		{
			LoadComponents();
			_state = BotStates.Idle;
			_running = true;
			RunBot();
		}

		private void MenuItem_Main_Click(object sender, EventArgs e)
		{
			SwitchComponent(ComponentIDs.Primary);
		}

		private void MenuItem_Pathfinding_Click(object sender, EventArgs e)
		{
			SwitchComponent(ComponentIDs.Pathfinding);
		}

		#endregion
	}
}


