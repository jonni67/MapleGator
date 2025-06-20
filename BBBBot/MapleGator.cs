using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace MapleGatorBot
{
    public partial class MapleGator : Form
    {
		#region Injections
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

		#region Process Memory

		const int PROCESS_ALL_ACCESS = 0x1F0FFF;
		const uint MEM_COMMIT = 0x1000;
		const uint MEM_RESERVE = 0x2000;
		const uint PAGE_READWRITE = 0x04;

		#endregion

		#region Private Members

		Dictionary<ComponentIDs, Form> _components;
		List<ComponentIDs> _componentIds;

		Primary _primary;
		Pathfinding _pathfinding;

		public MapleGator() { InitializeComponent(); }

		#endregion

		#region Public Methods

		public void HookProcess(string process)
		{
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

			IntPtr allocMemAddress = VirtualAllocEx(hProcess, IntPtr.Zero, (uint)((dllPath.Length + 1) * Marshal.SizeOf(typeof(char))),
													MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);

			if (allocMemAddress == IntPtr.Zero)
			{
				MessageBox.Show("Failed to allocate memory in target process.");
				CloseHandle(hProcess);
				return;
			}

			byte[] dllBytes = Encoding.ASCII.GetBytes(dllPath + "\0");
			WriteProcessMemory(hProcess, allocMemAddress, dllBytes, (uint)dllBytes.Length, out _);

			IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
			if (loadLibraryAddr == IntPtr.Zero)
			{
				MessageBox.Show("Failed to get address of LoadLibraryA.");
				CloseHandle(hProcess);
				return;
			}

			IntPtr remoteThread = CreateRemoteThread(hProcess, IntPtr.Zero, 0, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);
			if (remoteThread == IntPtr.Zero)
			{
				MessageBox.Show("Failed to create remote thread.");
			}
			else
			{
				MessageBox.Show("DLL injected successfully!");
			}

			CloseHandle(hProcess);
		}

		#endregion

		#region Private Methods

		private void LoadComponents()
		{
			_components = new Dictionary<ComponentIDs, Form>();
			_componentIds = new List<ComponentIDs>();

			_primary = new Primary(this);
			_pathfinding = new Pathfinding(this);

			// add components to dict
			_components.Add(ComponentIDs.Primary, _primary);
			_components.Add(ComponentIDs.Pathfinding, _pathfinding);

			// set all components in dict
			foreach (ComponentIDs id in Enum.GetValues(typeof(ComponentIDs)))
			{
				_components[id].MdiParent = this;
				_componentIds.Add(id);
			}

			// primary is first component shown on load
			SwitchComponent(ComponentIDs.Primary);
		}

		private void SwitchComponent(ComponentIDs id)
		{
			// switch off any components not id then show id
			_componentIds.Where(f => f != id).ToList().ForEach(f => _components[f].Hide());
			_components[id].Show();
		}

		#endregion

		#region Callbacks

		private void MapleGator_Load(object sender, EventArgs e)
		{
			LoadComponents();
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
