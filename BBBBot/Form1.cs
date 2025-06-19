using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BBBBot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load; // Hook form load event
            button_hook.Click += button_hook_Click; // Hook button click
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            foreach (var proc in Process.GetProcessesByName("MapleLegends"))
            {
                comboBox1.Items.Add($"{proc.ProcessName} (PID: {proc.Id})");
            }

            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
        }

        private void button_hook_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a MapleLegends process.");
                return;
            }

            // Extract PID from dropdown item
            string selected = comboBox1.SelectedItem.ToString();
            int pidStart = selected.IndexOf("PID: ") + 5;
            int pidEnd = selected.IndexOf(")", pidStart);
            string pidStr = selected.Substring(pidStart, pidEnd - pidStart);

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

        const int PROCESS_ALL_ACCESS = 0x1F0FFF;
        const uint MEM_COMMIT = 0x1000;
        const uint MEM_RESERVE = 0x2000;
        const uint PAGE_READWRITE = 0x04;
    }
}
