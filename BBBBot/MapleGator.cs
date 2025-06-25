using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Diagnostics;
using System.Threading;
using System.Net.NetworkInformation;
using System.Management;

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

		// Add these P/Invoke declarations if you don't have them:
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern uint WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool GetExitCodeThread(IntPtr hThread, out uint lpExitCode);

		[DllImport("kernel32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool GetExitCodeProcess(IntPtr hProcess, out uint lpExitCode);

		#endregion

		#region Public Fields

		public bool AutoLoginEnabled
		{
			get { return _autoLoginEnabled; }
			set { _autoLoginEnabled = value; }
		}

		public int StateDelayMs
		{
			get { return _stateDelayMs; }
		}

		public bool IMapOpen
		{
			get { return _iMapOpen; }
			set { _iMapOpen = value; }
		}

		#endregion

		#region Private Members

		// events
		event Action OnStopWatchTimeComplete;

		// memory hex //
		const int PROCESS_ALL_ACCESS = 0x1F0FFF;
		const uint MEM_COMMIT = 0x1000;
		const uint MEM_RESERVE = 0x2000;
		const uint PAGE_READWRITE = 0x04;
		const uint WAIT_OBJECT_0 = 0x00000000;
		const uint WAIT_TIMEOUT = 0x00000102;
		const int PROCESS_QUERY_LIMITED_INFORMATION = 0x1000;
		const uint STILL_ACTIVE = 259;

		// components //
		Dictionary<ComponentIDs, Form> _components;

		Primary _primary;
		Pathfinding _pathfinding;
		MovementController _moveController;
		AutoLogin _autoLogin;
		Form _shownComponent;

		// interactive map //
		InteractiveMap _iMap;

		// settings //
		int _stateDelayMs = 50;
		int _processListRefreshRate = 1000;

		// states //
		BotStates _state;
		WaitingStates _waitingState;

		Dictionary<BotStates, Action> _stateCallbacks;

		bool _hooking = false;
		bool _hooked = false;
		bool _autoLoginEnabled = false;
		bool _iMapOpen = false;

		int _currPID = -1;

		// timers //
		System.Windows.Forms.Timer _tickTimer = new System.Windows.Forms.Timer();
		System.Windows.Forms.Timer _sysTimer = new System.Windows.Forms.Timer();
		Stopwatch _stopWatch = Stopwatch.StartNew();
		float _stopWatchTime = 100f;
		bool _timerActive = false;

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

			Console.WriteLine(this.ClientSize);
		}

		public void HookProcess(string process)
		{
			if (_hooked)
				return;

			if(TryHookProcess(process))
			{
				_hooked = true;
				_hooking = false;
				_primary.HookedLabel.Text = "HOOKED";
				_primary.HookedLabel.ForeColor = Styling.COLOR_ON;
				_primary.HookedButton.Enabled = false;
				_primary.HookedButton.Visible = false;
				MessageBox.Show("DLL injected successfully!");
				return;
			}

			_hooked = false;
			_hooking = false;
			MessageBox.Show("DLL Failed to Inject :(");
		}

		public void SetUpdateRate(int val)
		{
			_tickTimer.Stop();
			_stateDelayMs = val;
			_tickTimer.Interval = _stateDelayMs;
			_tickTimer.Start();
		}	

		#endregion

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
			_autoLogin = new AutoLogin(this);

			// add components to dict
			_components.Add(ComponentIDs.Primary, _primary);
			_components.Add(ComponentIDs.AutoLogin, _autoLogin);
			_components.Add(ComponentIDs.Pathfinding, _pathfinding);

			// set all components in dict
			foreach (ComponentIDs id in Enum.GetValues(typeof(ComponentIDs)))
			{
				if (!_components.ContainsKey(id) || _components[id] == null)
					continue;
				_components[id].MdiParent = this;
			}
			
			// show all forms //
			_pathfinding.Show();
			_autoLogin.Show();
			_primary.Show();

			// then must hide all forms then show primary //
			// weird stuff happens otherwise when navigating //
			Styling.HideFormWithoutFlicker(_pathfinding);
			Styling.HideFormWithoutFlicker(_autoLogin);
			Styling.HideFormWithoutFlicker(_primary);
			Styling.ShowFormWithoutFlicker(_primary);

			_shownComponent = _components[ComponentIDs.Primary];

			_iMap = new InteractiveMap(this);
			Console.WriteLine("Loaded Form Components");
		}

		/// <summary>
		/// Switches to a new visible form component.
		/// </summary>
		private void SwitchComponent(ComponentIDs id)
		{
			if (_shownComponent.Name == _components[id].Name)
				return;

			Console.WriteLine(id.ToString());
			Console.WriteLine(_shownComponent.Name);

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

			/* determines the ACTUAL 
			 * usable client size of this MDI parent container
			Size t = Controls
			.OfType<MdiClient>()
			.FirstOrDefault().ClientSize;
			Console.WriteLine(t); */
		}

		private bool IsProcessRunning(int pid)
		{
			IntPtr hProcess = OpenProcess(PROCESS_QUERY_LIMITED_INFORMATION, false, pid);
			if (hProcess == IntPtr.Zero)
				return false;

			bool result = GetExitCodeProcess(hProcess, out uint exitCode);
			CloseHandle(hProcess);

			return result && exitCode == STILL_ACTIVE;
		}

		/// <summary>
		/// Injects to process via RemoteThread and LoadLibraryA
		/// </summary>
		/// <param name="process">The full name of the process.</param>
		private bool TryHookProcess(string process)
		{
			_hooking = true;
			_primary.StatusLabel.Text = "Hooking ...";

			// Extract PID
			int pidStart = process.IndexOf("PID: ") + 5;
			int pidEnd = process.IndexOf(")", pidStart);
			string pidStr = process.Substring(pidStart, pidEnd - pidStart);
			if (!int.TryParse(pidStr, out int pid))
			{
				MessageBox.Show("Invalid PID.");
				return false;
			}

			_currPID = pid;

			string dllPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "backend.dll");
			if (!File.Exists(dllPath))
			{
				MessageBox.Show("backend.dll not found in application directory.");
				return false;
			}

			IntPtr hProcess = OpenProcess(PROCESS_ALL_ACCESS, false, pid);
			if (hProcess == IntPtr.Zero)
			{
				MessageBox.Show("Failed to open target process.");
				return false;
			}

			try
			{
				IntPtr allocMemAddress = VirtualAllocEx(hProcess, IntPtr.Zero,
					(uint)((dllPath.Length + 1) * Marshal.SizeOf(typeof(char))),
					MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);

				if (allocMemAddress == IntPtr.Zero)
				{
					MessageBox.Show("Failed to allocate memory in target process.");
					return false;
				}

				byte[] dllBytes = Encoding.ASCII.GetBytes(dllPath + "\0");
				if (!WriteProcessMemory(hProcess, allocMemAddress, dllBytes, (uint)dllBytes.Length, out _))
				{
					MessageBox.Show("Failed to write DLL path to target process.");
					return false;
				}

				IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
				if (loadLibraryAddr == IntPtr.Zero)
				{
					MessageBox.Show("Failed to get address of LoadLibraryA.");
					return false;
				}

				IntPtr remoteThread = CreateRemoteThread(hProcess, IntPtr.Zero, 0, loadLibraryAddr,
					allocMemAddress, 0, IntPtr.Zero);

				if (remoteThread == IntPtr.Zero)
				{
					MessageBox.Show("Failed to create remote thread.");
					return false;
				}

				// Wait for the remote thread to complete
				uint waitResult = WaitForSingleObject(remoteThread, 10000); // 10 second timeout
				if (waitResult != WAIT_OBJECT_0)
				{
					MessageBox.Show("DLL injection thread did not complete in time.");
					CloseHandle(remoteThread);
					return false;
				}

				// Get the exit code to verify LoadLibrary succeeded
				if (GetExitCodeThread(remoteThread, out uint exitCode))
				{
					if (exitCode == 0) // LoadLibrary returns NULL on failure
					{
						MessageBox.Show("LoadLibrary failed in target process.");
						CloseHandle(remoteThread);
						return false;
					}
				}

				CloseHandle(remoteThread);
				// Wait for DLL to initialize its shared memory
				Thread.Sleep(1000);
				return true;
			}
			finally
			{
				CloseHandle(hProcess);
			}
		}

		private void ResetHook()
        {
			_currPID = -1;
			_moveController.Stop();
			_moveController.Cleanup();
			_stopWatch.Stop();
			_hooked = false;
			_primary.HookedButton.Enabled = true;
			_primary.HookedButton.Visible = true;
			_state = BotStates.Idle;

			_primary.HookedLabel.Text = "NOT HOOKED";
			_primary.HookedLabel.ForeColor = Styling.COLOR_OFF;
		}	

		#endregion

		#region Form Callbacks

		private void MapleGator_Load(object sender, EventArgs e)
		{
			LoadComponents();
			LoadStates();
			StartBot();
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			if (_moveController != null && _moveController.IsConnected())
			{
				_moveController.Stop();
				_moveController.Cleanup();
			}

			base.OnFormClosing(e);
		}

		private void MenuItem_Main_Click(object sender, EventArgs e)
		{
			SwitchComponent(ComponentIDs.Primary);
		}

		private void MenuItem_AutoLogin_Click(object snder, EventArgs e)
		{
			SwitchComponent(ComponentIDs.AutoLogin);
		}

		private void MenuItem_Pathfinding_Click(object sender, EventArgs e)
		{
			SwitchComponent(ComponentIDs.Pathfinding);
		}

		private void MenuItem_IMap_Click(object sender, EventArgs e)
		{
			if(!_iMapOpen)
			{
				_iMap.Show();
				_iMapOpen = true;
			}
		}

		#endregion
	}
}


