using System;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;

namespace MapleGatorBot
{
	public static class MacHWID
	{
		/// <summary>
		/// Generates a new simulated Mac Address
		/// </summary>
		/// <returns></returns>
		public static string GenerateRandomMac()
		{
			Random rand = new Random();
			byte[] mac = new byte[6];
			rand.NextBytes(mac);

			// Set the locally administered and unicast bits
			mac[0] = (byte)((mac[0] & 0xFE) | 0x02);

			return string.Join(":", mac.Select(b => b.ToString("X2")));
		}

		/// <summary>
		/// Generates a new simulated hardware ID
		/// </summary>
		/// <returns></returns>
		public static string GenerateRandomHwid()
		{
			// e.g., A1B2C3D4E5F67890ABCDEF1234567890
			return Guid.NewGuid().ToString("N").ToUpper();
		}

		/// <summary>
		/// Generates a new simulated hardware ID with specified length.
		/// </summary>
		/// <param name="length"></param>
		/// <returns></returns>
		public static string GenerateRandomHwidHex(int length = 32)
		{
			const string chars = "0123456789ABCDEF";
			Random rand = new Random();
			return new string(Enumerable.Repeat(chars, length)
										.Select(s => s[rand.Next(s.Length)]).ToArray());
		}

		/// <summary>
		/// Gets the official mac address.
		/// </summary>
		/// <returns></returns>
		public static string GetMacAddress()
		{
			return NetworkInterface.GetAllNetworkInterfaces()
				.Where(nic => nic.OperationalStatus == OperationalStatus.Up &&
							  nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
				.Select(nic => nic.GetPhysicalAddress().ToString())
				.FirstOrDefault();
		}

		/// <summary>
		/// Gets the official hardware ID of Mac-CPU-Volume-Board
		/// </summary>
		/// <returns></returns>
		public static string GetHardwareId()
		{
			var mac = GetMacAddress();
			var cpu = GetCpuId();
			var volume = GetVolumeSerial();
			var board = GetMotherboardSerial();

			return $"{mac}-{cpu}-{volume}-{board}";
		}

		public static string GetVolumeSerial(string driveLetter = "C")
		{
			ManagementObject disk = new ManagementObject($"win32_logicaldisk.deviceid=\"{driveLetter}:\"");
			disk.Get();
			return disk["VolumeSerialNumber"].ToString();
		}

		public static string GetCpuId()
		{
			using (var mc = new ManagementClass("win32_processor"))
			{
				foreach (var obj in mc.GetInstances())
				{
					return obj.Properties["ProcessorId"]?.Value?.ToString();
				}
			}
			return null;
		}

		public static string GetMotherboardSerial()
		{
			using (var searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BaseBoard"))
			{
				foreach (ManagementObject obj in searcher.Get())
				{
					return obj["SerialNumber"]?.ToString().Trim();
				}
			}
			return null;
		}
	}
}
