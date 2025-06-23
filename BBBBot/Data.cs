using System.Runtime.InteropServices;
using System;

namespace MapleGatorBot
{
	public enum ComponentIDs
	{
		Primary,
		Pathfinding,
		Metrics,
	}

	public enum BotStates
	{
		Idle,
		Waiting,
		Navigating,
		Moving,
		Attacking,
	}

	public enum WaitingStates
	{
		Initial,
		Waiting,
	}

	public enum MovingStates
	{
		MovingRight,
		MovingLeft,
		MovingUp,
		MovingDown,
		StopMove,
		MovingUpRight,
		MovingUpLeft,
		MovingDownLeft,
		MovingDownRight,
	}
}