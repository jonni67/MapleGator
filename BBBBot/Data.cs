﻿using System.Runtime.InteropServices;
using System;
using System.Drawing;
using SkiaSharp;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

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
		Trigger,
		Action,
	}

	public enum PlannerTriggerTypes
	{
		HPBelow,
		MPBelow,
		LevelRange,
	}

	public enum PlannerActionTypes
	{
		FollowRoutine,
		UseConsumable,
		WaitMS,
		WaitRandomMS,
		GotoMap,
		HuntInMap,
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

	public sealed class MapEntryValue
	{
		[JsonPropertyName("_value")]
		public string Value { get; set; }
	}

	public sealed class MapEntry
	{
		[JsonPropertyName("_dirName")]
		public string DirName { get; set; }

		[JsonPropertyName("_dirType")]
		public string DirType { get; set; }

		public MapEntryValue streetName { get; set; }
		public MapEntryValue mapName { get; set; }
		public MapEntryValue mapDesc { get; set; }
		public MapEntryValue help0 { get; set; }
	}

	public sealed class MapRegion
	{
		[JsonPropertyName("_dirName")]
		public string DirName { get; set; }

		[JsonPropertyName("_dirType")]
		public string DirType { get; set; }

		// Dictionary of all maps in the region
		[JsonExtensionData]
		public Dictionary<string, JsonElement> Maps { get; set; }
	}
}