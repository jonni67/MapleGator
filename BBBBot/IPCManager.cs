using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MapleGatorBot
{
	public static class IPCManager
	{
		public static bool IS_IPC_VALID = false;
		public static IPCDataArrays DATA_ARRAYS;

		static MemoryMappedFile gameDataFile;
		static MemoryMappedViewAccessor gameDataAccessor;
		static MemoryMappedFile arrayDataFile;
		static MemoryMappedViewAccessor arrayDataAccessor;

		static bool isMonitoring = false;
		static Thread monitorThread;

		public static void InitIPC()
		{
			Console.WriteLine("MapleGator IPC Test Client");
			Console.WriteLine("==========================");
			bool success = true;

			try
			{
				// Connect to shared memory
				gameDataFile = MemoryMappedFile.OpenExisting("MapleGatorGameData");
				gameDataAccessor = gameDataFile.CreateViewAccessor();

				arrayDataFile = MemoryMappedFile.OpenExisting("MapleGatorArrayData");
				arrayDataAccessor = arrayDataFile.CreateViewAccessor();

				Console.WriteLine("✓ Connected to shared memory");
				Console.WriteLine("Type 'help' for available commands");
				Console.WriteLine();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
				Console.WriteLine("Make sure the backend DLL is loaded in the game");
				success = false;
			}
			finally
			{
				//gameDataAccessor?.Dispose();
				//gameDataFile?.Dispose();
				//arrayDataAccessor?.Dispose();
				//arrayDataFile?.Dispose();
				//arrayViewStream?.Dispose();
			}

			IS_IPC_VALID = success;

		}

		public static void SendCommand(string cmd)
		{
			if (string.IsNullOrEmpty(cmd)) return;

			string[] parts = cmd.Split(' ');
			string command = parts[0];

			switch (command.ToLower())
			{
				case "init":
				case "i":
					SendInitialize();
					break;

				case "cleanup":
				case "c":
					SendCleanup();
					break;

				case "move":
				case "m":
					if (parts.Length >= 3 && int.TryParse(parts[1], out int x) && int.TryParse(parts[2], out int y))
					{
						SendMoveTo(x, y);
					}
					else
					{
						Console.WriteLine("Usage: move <x> <y>");
					}
					break;

				case "stop":
				case "s":
					SendStopMoveTo();
					break;

				case "refresh":
				case "r":
					SendRefreshMapData();
					break;

				case "navigate":
				case "nav":
					if (parts.Length >= 2 && int.TryParse(parts[1], out int mapId))
					{
						SendNavigateToMap(mapId);
					}
					else
					{
						Console.WriteLine("Usage: navigate <mapId>");
					}
					break;

				case "stopnav":
				case "sn":
					SendStopNavigation();
					break;

				case "status":
					ShowStatus();
					break;

				case "monitor":
					StartMonitoring();
					break;

				case "stopmonitor":
				case "sm":
					StopMonitoring();
					break;

				case "help":
				case "h":
					ShowHelp();
					break;

				case "exit":
				case "quit":
				case "q":
					StopMonitoring();
					return;

				default:
					Console.WriteLine($"Unknown command: {command}");
					Console.WriteLine("Type 'help' for available commands");
					break;
			}
		}

		public static void Test()
		{
			Console.WriteLine("MapleGator IPC Test Client");
			Console.WriteLine("==========================");

			try
			{
				// Connect to shared memory
				gameDataFile = MemoryMappedFile.OpenExisting("MapleGatorGameData");
				gameDataAccessor = gameDataFile.CreateViewAccessor();

				arrayDataFile = MemoryMappedFile.OpenExisting("MapleGatorArrayData");
				arrayDataAccessor = arrayDataFile.CreateViewAccessor();

				Console.WriteLine("✓ Connected to shared memory");
				Console.WriteLine("Type 'help' for available commands");
				Console.WriteLine();

				// Command loop
				while (true)
				{
					Console.Write("> ");
					string input = Console.ReadLine();
					if (string.IsNullOrEmpty(input)) continue;

					string[] parts = input.Split(' ');
					string command = parts[0];

					switch (command.ToLower())
					{
						case "init":
						case "i":
							SendInitialize();
							break;

						case "cleanup":
						case "c":
							SendCleanup();
							break;

						case "move":
						case "m":
							if (parts.Length >= 3 && int.TryParse(parts[1], out int x) && int.TryParse(parts[2], out int y))
							{
								SendMoveTo(x, y);
							}
							else
							{
								Console.WriteLine("Usage: move <x> <y>");
							}
							break;

						case "stop":
						case "s":
							SendStopMoveTo();
							break;

						case "refresh":
						case "r":
							SendRefreshMapData();
							break;

						case "navigate":
						case "nav":
							if (parts.Length >= 2 && int.TryParse(parts[1], out int mapId))
							{
								SendNavigateToMap(mapId);
							}
							else
							{
								Console.WriteLine("Usage: navigate <mapId>");
							}
							break;

						case "stopnav":
						case "sn":
							SendStopNavigation();
							break;

						case "status":
							ShowStatus();
							break;

						case "monitor":
							StartMonitoring();
							break;

						case "stopmonitor":
						case "sm":
							StopMonitoring();
							break;

						case "help":
						case "h":
							ShowHelp();
							break;

						case "exit":
						case "quit":
						case "q":
							StopMonitoring();
							return;

						default:
							Console.WriteLine($"Unknown command: {command}");
							Console.WriteLine("Type 'help' for available commands");
							break;
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
				Console.WriteLine("Make sure the backend DLL is loaded in the game");
			}
			finally
			{
				gameDataAccessor?.Dispose();
				gameDataFile?.Dispose();
				arrayDataAccessor?.Dispose();
				arrayDataFile?.Dispose();
			}
		}

		public static void DisposeAll()
		{
			gameDataAccessor?.Dispose();
			gameDataFile?.Dispose();
			arrayDataAccessor?.Dispose();
			arrayDataFile?.Dispose();
		}

		public static IPCGameData ReadGameData()
		{
			IPCGameData data;
			gameDataAccessor.Read(0, out data);
			return data;
		}

		public static void ReplaceGameData(ref IPCGameData s)
		{
			gameDataAccessor.Read(0, out s);
		}

		public static void ReplaceArrayData(ref IPCDataArrays s)
		{
			arrayDataAccessor.Read(0, out s);
		}

		static void WriteGameData(IPCGameData data)
		{
			gameDataAccessor.Write(0, ref data);
		}

		static void SendInitialize()
		{
			Console.WriteLine("Sending initialize command...");
			IPCGameData data = ReadGameData();
			data.initialize = 1;
			WriteGameData(data);

			Thread.Sleep(500);
			data = ReadGameData();
			Console.WriteLine($"✓ System initialized: {(data.systemInitialized == 1 ? "YES" : "NO")}");
			Console.WriteLine($"  Movement active: {(data.movementActive == 1 ? "YES" : "NO")}");
			Console.WriteLine($"  Pathfinding ready: {(data.pathfindingReady == 1 ? "YES" : "NO")}");
		}

		static void SendCleanup()
		{
			Console.WriteLine("Sending cleanup command...");
			IPCGameData data = ReadGameData();
			data.cleanup = 1;
			WriteGameData(data);

			Thread.Sleep(100);
			Console.WriteLine("✓ Cleanup command sent");
		}

		static void SendMoveTo(int x, int y)
		{
			Console.WriteLine($"Sending move to ({x}, {y}) command...");
			IPCGameData data = ReadGameData();
			data.moveToX = x;
			data.moveToY = y;
			data.moveToFlag = 1;
			WriteGameData(data);

			Thread.Sleep(100);
			data = ReadGameData();
			Console.WriteLine($"✓ MoveTo command sent - IsMovingTo: {(data.isMovingTo == 1 ? "YES" : "NO")}");
		}

		static void SendStopMoveTo()
		{
			Console.WriteLine("Sending stop MoveTo command...");
			IPCGameData data = ReadGameData();
			data.stopMoveToFlag = 1;
			WriteGameData(data);

			Thread.Sleep(100);
			data = ReadGameData();
			Console.WriteLine($"✓ Stop command sent - IsMovingTo: {(data.isMovingTo == 1 ? "YES" : "NO")}");
		}

		static void SendRequestMapData()
		{
			Console.WriteLine("Requesting all map data...");
			IPCGameData data = ReadGameData();
			data.requestMapData = 1;
			WriteGameData(data);

			Thread.Sleep(500);
			data = ReadGameData();
			Console.WriteLine($"✓ Map data ready: {(data.mapDataReady == 1 ? "YES" : "NO")}");
		}

		static void SendRefreshMapData()
		{
			Console.WriteLine("Sending refresh map data command...");
			IPCGameData data = ReadGameData();
			data.refreshMapData = 1;
			WriteGameData(data);

			Thread.Sleep(300);
			Console.WriteLine("✓ Refresh command sent");
		}

		static void SendNavigateToMap(int mapId)
		{
			Console.WriteLine($"Sending navigate to map {mapId} command...");
			IPCGameData data = ReadGameData();
			data.navigationTargetMapId = mapId;
			data.navigateToMapFlag = 1;
			WriteGameData(data);

			Thread.Sleep(100);
			data = ReadGameData();
			Console.WriteLine($"✓ Navigation started: {(data.isNavigating == 1 ? "YES" : "NO")}");
			Console.WriteLine("Use 'monitor' to watch progress");
		}

		static void SendStopNavigation()
		{
			Console.WriteLine("Sending stop navigation command...");
			IPCGameData data = ReadGameData();
			data.stopNavigationFlag = 1;
			WriteGameData(data);

			Thread.Sleep(100);
			Console.WriteLine("✓ Stop navigation command sent");
		}

		static void ShowStatus()
		{
			IPCGameData data = ReadGameData();

			Console.WriteLine("\n=== SYSTEM STATUS ===");
			Console.WriteLine($"Initialized: {(data.systemInitialized == 1 ? "YES" : "NO")}");
			Console.WriteLine($"Movement Active: {(data.movementActive == 1 ? "YES" : "NO")}");
			Console.WriteLine($"Pathfinding Ready: {(data.pathfindingReady == 1 ? "YES" : "NO")}");
			Console.WriteLine($"Movement Enabled: {(data.movementEnabled == 1 ? "YES" : "NO")}");
			Console.WriteLine($"Is Moving To: {(data.isMovingTo == 1 ? "YES" : "NO")}");
			Console.WriteLine($"Map Data Ready: {(data.mapDataReady == 1 ? "YES" : "NO")}");

			if (data.errorOccurred == 1)
			{
				Console.WriteLine($"\nERROR: Code {data.errorCode}");
				// REMOVED errorMessage handling - we don't have that field anymore
			}

			Console.WriteLine($"\n=== PLAYER INFO ===");
			Console.WriteLine($"Map ID: {data.currentMapID}");
			Console.WriteLine($"Position: ({data.playerX}, {data.playerY})");
			Console.WriteLine($"Animation: {data.playerAnimation}");
			Console.WriteLine($"Facing: {(data.playerFacing == 1 ? "Right" : "Left")}");
			Console.WriteLine($"Movement: ({data.currentMovementX}, {data.currentMovementY})");

			Console.WriteLine($"\n=== MAP INFO ===");
			Console.WriteLine($"Bounds: ({data.mapLeft}, {data.mapTop}) to ({data.mapRight}, {data.mapBottom})");
			Console.WriteLine($"Entities: {data.totalMobs} mobs, {data.totalDrops} drops");
			Console.WriteLine($"Portals: {data.totalPortals}, Footholds: {data.totalFootholds}");

			if (data.isNavigating == 1)
			{
				Console.WriteLine($"\n=== NAVIGATION ===");
				Console.WriteLine($"Status: {GetNavigationStatusName((NavigationStatus)data.navigationStatus)}");
				Console.WriteLine($"Progress: Step {data.navigationCurrentStep} of {data.navigationTotalSteps}");
				Console.WriteLine($"Target Map: {data.navigationTargetMapId}");
			}

			Console.WriteLine($"\n=== TIMING ===");
			Console.WriteLine($"Last Update: {data.lastUpdateTime}");
			Console.WriteLine($"Frame Time: {data.frameTime}ms");
		}

		static void ShowHelp()
		{
			Console.WriteLine("\nAvailable commands:");
			Console.WriteLine("  init (i)          - Initialize the backend systems");
			Console.WriteLine("  cleanup (c)       - Clean up and shut down systems");
			Console.WriteLine("  move <x> <y> (m)  - Move character to coordinates");
			Console.WriteLine("  stop (s)          - Stop current movement");
			Console.WriteLine("  refresh (r)       - Refresh all map data");
			Console.WriteLine("  navigate <mapId>  - Navigate to a different map");
			Console.WriteLine("  stopnav (sn)      - Stop map navigation");
			Console.WriteLine("  status            - Show current status");
			Console.WriteLine("  monitor           - Start real-time monitoring");
			Console.WriteLine("  stopmonitor (sm)  - Stop monitoring");
			Console.WriteLine("  help (h)          - Show this help");
			Console.WriteLine("  exit (q)          - Exit the program");
		}

		static void StartMonitoring()
		{
			if (isMonitoring)
			{
				Console.WriteLine("Already monitoring");
				return;
			}

			isMonitoring = true;
			monitorThread = new Thread(MonitorThreadFunction);
			monitorThread.Start();
			Console.WriteLine("Started monitoring (press Enter to stop)");
			Console.ReadLine();
			StopMonitoring();
		}

		static void StopMonitoring()
		{
			if (!isMonitoring) return;

			isMonitoring = false;
			if (monitorThread != null && monitorThread.IsAlive)
			{
				monitorThread.Join();
			}
			Console.WriteLine("Monitoring stopped");
		}

		static void MonitorThreadFunction()
		{
			while (isMonitoring)
			{
				IPCGameData data = ReadGameData();

				Console.Clear();
				Console.WriteLine("=== REAL-TIME MONITOR === (Press Enter to stop)");
				Console.WriteLine($"Time: {DateTime.Now:HH:mm:ss.fff}");

				Console.WriteLine($"\nPlayer: ({data.playerX}, {data.playerY}) Map: {data.currentMapID}");
				Console.WriteLine($"Moving: {(data.isMovingTo == 1 ? "YES" : "NO")} | Movement: ({data.currentMovementX}, {data.currentMovementY})");

				if (data.isNavigating == 1)
				{
					Console.WriteLine($"\nNavigating to map {data.navigationTargetMapId}");
					Console.WriteLine($"Status: {GetNavigationStatusShort((NavigationStatus)data.navigationStatus)}");
					Console.WriteLine($"Step {data.navigationCurrentStep}/{data.navigationTotalSteps}");
				}

				if (data.errorOccurred == 1)
				{
					Console.WriteLine($"\nERROR: Code {data.errorCode}");
				}

				Thread.Sleep(100);
			}
		}

		static string GetNavigationStatusName(NavigationStatus status)
		{
			switch (status)
			{
				case NavigationStatus.Idle: return "Idle";
				case NavigationStatus.Planning: return "Planning route";
				case NavigationStatus.NavigatingToPortal: return "Moving to portal";
				case NavigationStatus.UsingPortal: return "Using portal";
				case NavigationStatus.WaitingForMapChange: return "Waiting for map change";
				case NavigationStatus.Completed: return "Navigation completed";
				case NavigationStatus.Failed: return "Navigation failed";
				case NavigationStatus.Stopped: return "Navigation stopped";
				default: return $"Unknown ({(int)status})";
			}
		}

		static string GetNavigationStatusShort(NavigationStatus status)
		{
			switch (status)
			{
				case NavigationStatus.Idle: return "Idle";
				case NavigationStatus.Planning: return "Plan";
				case NavigationStatus.NavigatingToPortal: return "Move";
				case NavigationStatus.UsingPortal: return "Port";
				case NavigationStatus.WaitingForMapChange: return "Wait";
				case NavigationStatus.Completed: return "Done";
				case NavigationStatus.Failed: return "Fail";
				case NavigationStatus.Stopped: return "Stop";
				default: return "?";
			}
		}
	}
}
