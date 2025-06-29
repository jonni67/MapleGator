using System.Runtime.InteropServices;
using System;
using System.Drawing;
using SkiaSharp;

namespace MapleGatorBot
{
	public enum ComponentIDs
	{
		Primary,
		AutoLogin,
		Planner,
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

	public enum IMapDrawModes
	{
		HuntRectangle,
		DeadZone,
	}

	public enum PlannerElementTypes
	{
		Routine,
		Trigger,
		Action,
	}

	public struct HuntZone
	{
		public PointF Start;
		public PointF End;
		public PointF MidPoint;
		public string Name;
		public SKRect Rect;

		public HuntZone(PointF start, PointF end, string name)
		{
			this.Start = start;
			this.End = end;
			this.Name = name;

			float midX = (Start.X + End.X) / 2;
			float midY = (Start.Y + End.Y) / 2;
			this.MidPoint = new PointF(midX, midY);

			this.Rect = new SKRect(Start.X, Start.Y, Start.X + Math.Abs(Start.X - End.X), Start.Y + Math.Abs(Start.Y - End.Y) - 32);
		}
	}
}