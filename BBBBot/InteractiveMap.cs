using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using SkiaSharp;
using SkiaSharp.Views.Desktop;

namespace MapleGatorBot
{
	public partial class InteractiveMap : Form
	{
		MapleGator _parent;
		private SKControl skControl;

		bool _isDrawing = false;
		List<HuntZone> _huntZones = new List<HuntZone>();

		SKRect _currHuntZoneDraw = new SKRect();
		IPCFootholdData _currHoveredFoothold = new IPCFootholdData();

		List<PointF> _huntZonePoints = new List<PointF>();

		float mapLeft = -250;
		float mapRight = 1690;
		float mapTop = -935;
		float mapBottom = 415;

		float mapWidth = 0;
		float mapHeight = 0;

		float scaleX = 0;
		float scaleY = 0;
		float scale = 0;

		float testX = 0;
		float testY = 128;
		int testDir = 1;

		List<PointF> _screenHuntPoints = new List<PointF>();

		bool _isCreatingHuntZone = false;
		byte _huntZoneCreationState = 0;

		IMapDrawModes _drawMode;

		float _footHoldPointRadi = 6;
		SKPaint _paint_footHoldPoint = new SKPaint {
			Color = SKColors.Aqua,
			IsAntialias = true,
		};

		float _footHoldSelectRadi = 8;
		SKPaint _paint_footHoldSelectPoint = new SKPaint
		{
			Color = SKColors.Honeydew,
			IsAntialias = true,
		};

		SKPaint _paint_footHoldHoverPoint = new SKPaint
		{
			Color = SKColors.Magenta,
			IsAntialias = true,
		};

		SKPaint _paint_HuntZoneText = new SKPaint
        {
            Color = SKColors.DarkBlue,
			TextSize = 18,
            IsAntialias = true,
            Typeface = SKTypeface.FromFamilyName("Arial", SKFontStyle.Bold)
        };

		public InteractiveMap(MapleGator parent)
		{
			_parent = parent;
			InitializeComponent();

			skControl = new SKControl
			{
				Dock = DockStyle.Fill
			};

			skControl.PaintSurface += SkControl_PaintSurface;
			Controls.Add(skControl);

			var timer = new Timer { Interval = 1 };
			timer.Tick += (s, e) => skControl.Invalidate();
			timer.Tick += (s, e) => 
			{ 
				testX += 2 * testDir;
				if (testX >= 500)
				{
					testDir = -1;
				}
				if(testX <= 0)
				{
					testDir = 1;
				}
			};

			timer.Start();

			skControl.MouseDown += DoMouseClick;
			skControl.MouseUp += DoMouseUp;
			skControl.MouseMove += DoMouseMove;

			_drawMode = IMapDrawModes.HuntRectangle;
		}

		public void UpdateMapSize()
		{
			mapLeft = IPCManager.GAME_DATA.mapLeft;
			mapRight = IPCManager.GAME_DATA.mapRight;
			mapTop = IPCManager.GAME_DATA.mapTop;
			mapBottom = IPCManager.GAME_DATA.mapBottom;
			mapWidth = mapRight - mapLeft;
			mapHeight = mapBottom - mapTop;

			scaleX = this.ClientSize.Width / mapWidth;
			scaleY = this.ClientSize.Height / mapHeight;
			scale = Math.Min(scaleX, scaleY); // maintain aspect ratio

			Console.WriteLine($"left: {mapLeft}, right: {mapRight}, top: {mapTop}, bottom: {mapBottom}");
		}

		public PointF GetWorldHuntPoint(int index)
		{
			return _screenHuntPoints[index];
		}

		private PointF ConvertScreenToMap(Point screenPoint, float scale, float mapLeft, float mapTop)
		{
			float mapX = screenPoint.X / scale + mapLeft;
			float mapY = screenPoint.Y / scale + mapTop;
			return new PointF(mapX, mapY);
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			_parent.IMapOpen = false;
			e.Cancel = true;
			this.Hide();
		}

		private void DoMouseClick(object snder, MouseEventArgs e)
		{
			if(_isCreatingHuntZone)
			{
				PointF converted = ConvertScreenToMap(new Point(e.Location.X, e.Location.Y), scale, mapLeft, mapTop);
				IPCFootholdData closest = FindClosestFootholdToPoint(converted);
				_huntZonePoints.Add(new PointF(closest.x1, closest.y1));
				if(_huntZoneCreationState == 0)
				{
					_huntZoneCreationState = 1;
				}
				else if(_huntZoneCreationState == 1)
				{
					_isCreatingHuntZone = false;
					_huntZones.Add(new HuntZone(_huntZonePoints[0], _huntZonePoints[1], $"HUNT ZONE {_huntZones.Count}"));
					infoLabel.Text = "Use the menu to add new zones.";
				}
			}
		}

		private void DoMouseUp(object snder, MouseEventArgs e)
		{
			if (!_isDrawing)
				return;
		}

		private void DoMouseMove(object snder, MouseEventArgs e)
		{
			/*
			if (!_isDrawing)
				return;

			
			int xDiff = Math.Abs(_huntZoneStart.X - e.Location.X);
			int yDiff = Math.Abs(_huntZoneStart.Y - e.Location.Y);

			PointF converted = ConvertScreenToMap(new Point(_huntZoneStart.X, _huntZoneStart.Y), scale, mapLeft, mapTop);
			//_currHuntZoneDraw = CreateRect((int)converted.X, (int)converted.Y, xDiff, yDiff);
			*/

			if (_isCreatingHuntZone)
			{
				PointF converted = ConvertScreenToMap(new Point(e.Location.X, e.Location.Y), scale, mapLeft, mapTop);
				IPCFootholdData closest = FindClosestFootholdToPoint(converted);
				_currHoveredFoothold = closest;
			}
		}

		private void SkControl_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
		{
			var canvas = e.Surface.Canvas;
			canvas.Clear(SKColors.SlateGray);

			canvas.Scale(scale);
			canvas.Translate(-mapLeft, -mapTop);

			//canvas.DrawRect(CreateRect(testX, testY, 32, 32), new SKPaint { Color = SKColors.Red });

			for (int i = 0; i < IPCManager.GAME_DATA.totalMobs; i++)
			{
				//Console.WriteLine($"[Mob {i}] (X: {_currArrayData.mobs[i].x}, Y: {_currArrayData.mobs[i].y})");
				//Console.WriteLine($"[Mob {i}] (X: {IPCManager.ARRAY_DATA.mobs[i].x}, Y: {IPCManager.ARRAY_DATA.mobs[i].y})");
				int x = (IPCManager.ARRAY_DATA.mobs[i].x) - 32;
				int y = (IPCManager.ARRAY_DATA.mobs[i].y) - 32;
				canvas.DrawRect(CreateRect(x, y, 32, 32), new SKPaint { Color = SKColors.Red });
			}

			for (int i = 0; i < IPCManager.GAME_DATA.totalFootholds; i++)
			{
				IPCFootholdData d = IPCManager.ARRAY_DATA.footholds[i];
				canvas.DrawLine(d.x1, d.y1, d.x2, d.y2, new SKPaint { Color = SKColors.White });

				if(_isCreatingHuntZone)
				{
					if(_currHoveredFoothold.x1 == d.x1 && _currHoveredFoothold.y1 == d.y1)
					{
						canvas.DrawCircle(new SKPoint(d.x1, d.y1), _footHoldSelectRadi, _paint_footHoldHoverPoint);
					}
					else if(_huntZonePoints.Contains(new PointF(d.x1, d.y1)))
					{
						canvas.DrawCircle(new SKPoint(d.x1, d.y1), _footHoldSelectRadi, _paint_footHoldSelectPoint);
					}
					else
					{
						canvas.DrawCircle(new SKPoint(d.x1, d.y1), _footHoldPointRadi, _paint_footHoldPoint);
					}
				}
			}

			for (int i = 0; i < _huntZones.Count; i++)
			{
				canvas.DrawCircle(new SKPoint(_huntZones[i].Start.X, _huntZones[i].Start.Y), _footHoldSelectRadi, _paint_footHoldSelectPoint);
				canvas.DrawCircle(new SKPoint(_huntZones[i].End.X, _huntZones[i].End.Y), _footHoldSelectRadi, _paint_footHoldSelectPoint);
				canvas.DrawText(_huntZones[i].Name, _huntZones[i].MidPoint.X, _huntZones[i].MidPoint.Y - 32, _paint_HuntZoneText);
				canvas.DrawRect(_huntZones[i].Rect, new SKPaint { Color = SKColors.Green });
			}
		}

		public IPCFootholdData FindClosestFootholdToPoint(PointF point)
		{
			float smallestDist = 1000000f;
			IPCFootholdData closest = new IPCFootholdData();

			for (int i = 0; i < IPCManager.GAME_DATA.totalFootholds; i++)
			{
				float x1 = IPCManager.ARRAY_DATA.footholds[i].x1;
				float x2 = point.X;

				float y1 = IPCManager.ARRAY_DATA.footholds[i].y1;
				float y2 = point.Y;

				float dx = x2 - x1;
				float dy = y2 - y1;
				
				// finding squared distance is a bit more efficient and works fine
				float dist = dx * dx + dy * dy;

				if (dist >= 256)
					continue;

				if(dist < smallestDist)
				{
					smallestDist = dist;
					closest = IPCManager.ARRAY_DATA.footholds[i];
				}
			}

			return closest;
		}

		public static SKRect CreateRect(float x, float y, float width, float height)
		{
			return new SKRect(x, y, x + width, y + height);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			PointF huntPoint = GetWorldHuntPoint(0);
			int x = (int)huntPoint.X;
			int y = (int)huntPoint.Y;
			IPCManager.SendCommand($"m {x} {y}");
		}

		private void huntZoneToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_isCreatingHuntZone = true;
			_huntZonePoints.Clear();
			_huntZoneCreationState = 0;
			infoLabel.Text = "Use Left Mouse to select two points on the map. Right Mouse to cancel placement.";
		}
	}
}
