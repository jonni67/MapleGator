using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO.MemoryMappedFiles;
using System.Text;

namespace MapleGatorBot
{
	// IPCGameData structure matching C++ exactly
	// === FIXED C# Structure ===

	[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 164)]
	public struct IPCGameData
	{
		// === COMMAND SECTION (C# -> C++) ===
		// Basic commands
		public byte initialize;           // offset 0
		public byte cleanup;              // offset 1
		public byte refreshMapData;       // offset 2
		public byte reserved1;            // offset 3 (was stopAllMovement)

		// Movement commands (simplified)
		public byte reserved2;            // offset 4 (was enableMovement)
		public byte reserved3;            // offset 5 (was disableMovement)
		public byte moveToFlag;           // offset 6
		public byte stopMoveToFlag;       // offset 7
		public int moveToX;               // offset 8-11
		public int moveToY;               // offset 12-15

		// Removed pathfinding commands - now reserved
		public byte reserved4;            // offset 16 (was findPathFlag)
		public byte reserved5;            // offset 17 (was executePath)
		public int reserved6;             // offset 18-21 (was pathTargetX)
		public int reserved7;             // offset 22-25 (was pathTargetY)

		// Data request commands
		public byte requestMapData;       // offset 26
		public byte requestMobData;       // offset 27
		public byte requestDropData;      // offset 28
		public byte requestPortalData;    // offset 29
		public byte requestPathData;      // offset 30

		// Navigation commands
		public byte navigateToMapFlag;    // offset 31
		public byte stopNavigationFlag;   // offset 32
		public int navigationTargetMapId; // offset 33-36

		// === RESPONSE SECTION (C++ -> C#) ===
		// System status
		public byte systemInitialized;    // offset 37
		public byte movementActive;       // offset 38
		public byte pathfindingReady;     // offset 39
		public byte isMovingTo;           // offset 40
		public byte mapDataReady;         // offset 41

		// Error handling
		public byte errorOccurred;        // offset 42
		public int errorCode;             // offset 43-46

		// Current game state
		public int currentMapID;          // offset 47-50
		public int playerX;               // offset 51-54
		public int playerY;               // offset 55-58
		public int playerAnimation;       // offset 59-62
		public int playerFacing;          // offset 63-66

		// Map bounds
		public int mapLeft;               // offset 67-70
		public int mapRight;              // offset 71-74
		public int mapTop;                // offset 75-78
		public int mapBottom;             // offset 79-82

		// Entity counts
		public int totalMobs;             // offset 83-86
		public int totalDrops;            // offset 87-90
		public int totalPortals;          // offset 91-94
		public int totalFootholds;        // offset 95-98

		// Current movement state
		public int currentMovementX;      // offset 99-102
		public int currentMovementY;      // offset 103-106

		// Status flags
		public byte movementEnabled;      // offset 107
		public byte reserved8;            // offset 108 (was pathFound)
		public byte reserved9;            // offset 109 (was pathType)
		public int reserved10;            // offset 110-113 (was pathDistance)
		public int reserved11;            // offset 114-117 (was pathSteps)

		// Timing information - KEEP AS uint!
		public uint lastUpdateTime;       // offset 118-121
		public uint frameTime;            // offset 122-125

		// Navigation status
		public byte isNavigating;         // offset 126
		public byte navigationStatus;     // offset 127
		public int navigationCurrentStep; // offset 128-131
		public int navigationTotalSteps;  // offset 132-135

		// Reserved bytes - USE INDIVIDUAL BYTES LIKE THE OLD VERSION!
		public byte reserved12, reserved13, reserved14, reserved15;
		public byte reserved16, reserved17, reserved18, reserved19;
		public byte reserved20, reserved21, reserved22, reserved23;
		public byte reserved24, reserved25, reserved26, reserved27;
		public byte reserved28, reserved29, reserved30, reserved31;
		public byte reserved32, reserved33, reserved34, reserved35;
		public byte reserved36, reserved37, reserved38, reserved39;
	}

	// Navigation status enum
	public enum NavigationStatus : byte
	{
		Idle = 0,
		Planning = 1,
		NavigatingToPortal = 2,
		UsingPortal = 3,
		WaitingForMapChange = 4,
		Completed = 5,
		Failed = 6,
		Stopped = 7
	}

	// Complete IPC data arrays structure - IMPORTANT: counts are at the END
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct IPCDataArrays
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
		public IPCMobData[] mobs;           // 100 * 65 = 6500 bytes

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
		public IPCDropData[] drops;         // 50 * 49 = 2450 bytes

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
		public IPCPortalData[] portals;     // 20 * 81 = 1620 bytes

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 200)]
		public IPCFootholdData[] footholds; // 200 * 29 = 5800 bytes

		// These counts come AFTER all the arrays
		public int mobCount;         // offset 16370
		public int dropCount;        // offset 16374
		public int portalCount;      // offset 16378
		public int footholdCount;    // offset 16382
	}


	// Enhanced mob data structure matching C++ IPCMobData (65 bytes)
	[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 65)]
	public struct IPCMobData
	{
		public int mobUID;           // offset 0-3
		public int x;                // offset 4-7
		public int y;                // offset 8-11
		public int modelNumber;      // offset 12-15
		public int level;            // offset 16-19
		public int maxHP;            // offset 20-23
		public int currentHP;        // offset 24-27
		public int hpPercent;        // offset 28-31
		public byte isValid;         // offset 32
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		public byte[] name;          // offset 33-64

		public string GetName()
		{
			if (name == null) return "Unknown";
			int nullIndex = Array.IndexOf(name, (byte)0);
			if (nullIndex == -1) nullIndex = name.Length;
			return Encoding.ASCII.GetString(name, 0, nullIndex);
		}
	}


	// Enhanced drop data structure (49 bytes)
	[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 49)]
	public struct IPCDropData
	{
		public int dropUID;          // offset 0-3
		public int itemID;           // offset 4-7
		public int x;                // offset 8-11
		public int y;                // offset 12-15
		public byte isValid;         // offset 16
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		public byte[] itemName;      // offset 17-48

		public string GetItemName()
		{
			if (itemName == null) return "Unknown";
			int nullIndex = Array.IndexOf(itemName, (byte)0);
			if (nullIndex == -1) nullIndex = itemName.Length;
			return Encoding.ASCII.GetString(itemName, 0, nullIndex);
		}
	}

	// Enhanced portal data structure (81 bytes)
	[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 81)]
	public struct IPCPortalData
	{
		public int portalID;         // offset 0-3
		public int x;                // offset 4-7
		public int y;                // offset 8-11
		public int toMapID;          // offset 12-15
		public byte isValid;         // offset 16
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		public byte[] portalName;    // offset 17-48
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		public byte[] destinationName; // offset 49-80

		public string GetPortalName()
		{
			if (portalName == null) return "";
			int nullIndex = Array.IndexOf(portalName, (byte)0);
			if (nullIndex == -1) nullIndex = portalName.Length;
			return Encoding.ASCII.GetString(portalName, 0, nullIndex);
		}

		public string GetDestinationName()
		{
			if (destinationName == null) return "";
			int nullIndex = Array.IndexOf(destinationName, (byte)0);
			if (nullIndex == -1) nullIndex = destinationName.Length;
			return Encoding.ASCII.GetString(destinationName, 0, nullIndex);
		}
	}

	// Foothold data structure (29 bytes)
	[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 29)]
	public struct IPCFootholdData
	{
		public int footholdID;       // offset 0-3
		public int x1;               // offset 4-7
		public int y1;               // offset 8-11
		public int x2;               // offset 12-15
		public int y2;               // offset 16-19
		public int prev;             // offset 20-23
		public int next;             // offset 24-27
		public byte isValid;         // offset 28
	}

}