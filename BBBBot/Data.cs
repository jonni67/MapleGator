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
}