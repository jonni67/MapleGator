using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MapleGatorBot
{
	public class MovementController
	{
		private const string DLL_NAME = "Backend.dll";

		[DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall)]
		private static extern bool InitializeMovementHook();

		[DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall)]
		private static extern void CleanupMovementHook();

		[DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall)]
		private static extern void SetMovement(int leftRight, int upDown);

		[DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall)]
		private static extern void EnableMovement(bool enable);

		[DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall)]
		private static extern void EnableAttract(bool enable);

		[DllImport(DLL_NAME, CallingConvention = CallingConvention.StdCall)]
		private static extern bool IsHookActive();

		public static bool Initialized = false;

		// Initialize the system (call once at startup)
		public bool Initialize()
		{
			return InitializeMovementHook();
		}

		// Start movement control (call before moving)
		public void Start()
		{
			EnableAttract(true);    // MUST be called first
			EnableMovement(true);   // Then enable movement
		}

		// Stop movement control
		public void Stop()
		{
			SetMovement(0, 0);      // Stop moving
			EnableMovement(false);
			EnableAttract(false);
		}

		// Cleanup (call when done)
		public void Cleanup()
		{
			Stop();
			CleanupMovementHook();
		}

		// Basic directions
		public void MoveLeft() => SetMovement(-1, 0);
		public void MoveRight() => SetMovement(1, 0);
		public void MoveUp() => SetMovement(0, -1);
		public void MoveDown() => SetMovement(0, 1);
		public void StopMove() => SetMovement(0, 0);

		// Diagonal movement
		public void MoveUpLeft() => SetMovement(-1, -1);
		public void MoveUpRight() => SetMovement(1, -1);
		public void MoveDownLeft() => SetMovement(-1, 1);
		public void MoveDownRight() => SetMovement(1, 1);

		// Custom movement
		public void Move(int horizontal, int vertical)
		{
			// horizontal: -1=left, 0=stop, 1=right
			// vertical:   -1=up,   0=stop, 1=down
			SetMovement(horizontal, vertical);
		}
	}
}
