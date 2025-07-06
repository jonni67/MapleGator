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
		#region Private Members

		// references //

		MapleGator _parent;
		SKControl _control;

		// references //

		// settings //

		int _canvasRefreshRate = 16;
		static string _typeFace = "Bahnschrift Condensed";

		// settings //

		// states //

		bool _isDrawing = false;
		bool _isCreatingHuntZone = false;
		byte _huntZoneCreationState = 0;

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

		// states //

		// cache //

		IPCFootholdData _currHoveredFoothold = new IPCFootholdData();
		List<HuntZone> _huntZones = new List<HuntZone>();
		List<SKPoint> _huntZonePoints = new List<SKPoint>();
		List<PointF> _screenHuntPoints = new List<PointF>();

		// cache //

		// design //

		SKColor _bgColor = new SKColor(16, 16, 16);

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
            Color = SKColors.Green,
			TextSize = 36,
            IsAntialias = true,
            Typeface = SKTypeface.FromFamilyName(_typeFace, SKFontStyle.Bold)
        };

		SKPaint _paint_mobs = new SKPaint
		{
			Color = SKColors.Red,
			IsAntialias = true,
			Style = SKPaintStyle.Stroke,
			StrokeWidth = 4
		};

		SKPaint _paint_footholds = new SKPaint
		{
			Color = SKColors.FloralWhite,
			IsAntialias = true,
			Style = SKPaintStyle.Stroke,
			StrokeWidth = 2
		};

		SKPaint _paint_huntZone = new SKPaint
		{
			Color = SKColors.Green,
			IsAntialias = true,
			Style = SKPaintStyle.Stroke,
			StrokeWidth = 2,
		};

		// design //

		#endregion

		#region Public Methods

		public InteractiveMap(MapleGator parent)
		{
			_parent = parent;
			InitializeComponent();

			_control = new SKControl
			{
				Dock = DockStyle.Fill
			};

			_control.PaintSurface += SkControl_PaintSurface;
			Controls.Add(_control);

			var timer = new Timer { Interval = _canvasRefreshRate };
			timer.Tick += (s, e) => _control.Invalidate();
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

			_control.MouseDown += DoMouseClick;
			_control.MouseUp += DoMouseUp;
			_control.MouseMove += DoMouseMove;
		}

		public void UpdateMapSize()
		{
			mapLeft = IPCManager.GAME_DATA.mapLeft;
			mapRight = IPCManager.GAME_DATA.mapRight;
			mapTop = IPCManager.GAME_DATA.mapTop;
			mapBottom = IPCManager.GAME_DATA.mapBottom;
			mapWidth = mapRight - mapLeft;
			mapHeight = mapBottom - mapTop;

			scaleX = ClientSize.Width / mapWidth;
			scaleY = ClientSize.Height / mapHeight;
			scale = Math.Min(scaleX, scaleY); // maintain aspect ratio

			Console.WriteLine($"MAP: left: {mapLeft}, right: {mapRight}, top: {mapTop}, bottom: {mapBottom}");
		}

		#endregion

		#region Private Methods

		private PointF GetWorldHuntPoint(int index)
		{
			return _screenHuntPoints[index];
		}

		private SKRect CreateRect(float x, float y, float width, float height)
		{
			return new SKRect(x, y, x + width, y + height);
		}

		private IPCFootholdData FindClosestFootholdToPoint(SKPoint point)
		{
			float smallestDist = float.MaxValue;
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

				if (dist < smallestDist)
				{
					smallestDist = dist;
					closest = IPCManager.ARRAY_DATA.footholds[i];
				}
			}

			return closest;
		}

		private SKPoint ConvertScreenToMap(Point screenPoint, float scale, float mapLeft, float mapTop)
		{
			float mapX = screenPoint.X / scale + mapLeft;
			float mapY = screenPoint.Y / scale + mapTop;
			return new SKPoint(mapX, mapY);
		}

		private void DrawMobs(SKCanvas canvas)
		{
			for (int i = 0; i < IPCManager.GAME_DATA.totalMobs; i++)
			{
				int x = (IPCManager.ARRAY_DATA.mobs[i].x) - 32;
				int y = (IPCManager.ARRAY_DATA.mobs[i].y) - 32;
				//canvas.DrawRect(CreateRect(x, y, 32, 32), _paint_mobs);
				canvas.DrawOval(CreateRect(x, y, 32, 32), _paint_mobs);
			}
		}

		private void DrawFootHolds(SKCanvas canvas)
		{
			for (int i = 0; i < IPCManager.GAME_DATA.totalFootholds; i++)
			{
				IPCFootholdData d = IPCManager.ARRAY_DATA.footholds[i];
				canvas.DrawLine(d.x1, d.y1, d.x2, d.y2, _paint_footholds);

				if (_isCreatingHuntZone)
				{
					DrawHuntZoneSelection(canvas, ref d);
				}
			}
		}

		private void DrawPortals(SKCanvas canvas)
		{
			for(int i = 0; i < IPCManager.GAME_DATA.totalPortals; i++)
			{
				IPCPortalData d = IPCManager.ARRAY_DATA.portals[i];
				canvas.DrawRect(CreateRect(d.x, d.y - 64, 32, 64), new SKPaint { Color = SKColors.Teal });
			}
		}

		private void DrawPlayer(SKCanvas canvas)
		{
			canvas.DrawRect(CreateRect(IPCManager.GAME_DATA.playerX, IPCManager.GAME_DATA.playerY - 64, 32, 64), new SKPaint { Color = SKColors.GreenYellow });
		}

		[Obsolete]
		private void DrawHuntZones(SKCanvas canvas)
		{
			for (int i = 0; i < _huntZones.Count; i++)
			{
				canvas.DrawCircle(new SKPoint(_huntZones[i].Start.X, _huntZones[i].Start.Y), _footHoldSelectRadi, _paint_footHoldSelectPoint);
				canvas.DrawCircle(new SKPoint(_huntZones[i].End.X, _huntZones[i].End.Y), _footHoldSelectRadi, _paint_footHoldSelectPoint);

				SKPoint mid = _huntZones[i].MidPoint;
				// Size t = TextRenderer.MeasureText(_huntZones[i].Name, new Font(_typeFace, 0));

				float width = _paint_HuntZoneText.MeasureText(_huntZones[i].Name) / 2;
				SKPoint final = new SKPoint(mid.X - width, mid.Y);

				canvas.DrawText(_huntZones[i].Name, final, _paint_HuntZoneText);
				canvas.DrawRect(_huntZones[i].Rect, _paint_huntZone);
			}
		}

		private void DrawHuntZoneSelection(SKCanvas canvas, ref IPCFootholdData d)
		{
			SKPoint p = new SKPoint(d.x1, d.y1);

			if (_currHoveredFoothold.x1 == d.x1 && _currHoveredFoothold.y1 == d.y1)
			{
				canvas.DrawCircle(p, _footHoldSelectRadi, _paint_footHoldHoverPoint);
				return;
			}
			if (_huntZonePoints.Contains(p))
			{
				canvas.DrawCircle(p, _footHoldSelectRadi, _paint_footHoldSelectPoint);
				return;
			}

			canvas.DrawCircle(p, _footHoldPointRadi, _paint_footHoldPoint);
		}

		#endregion

		#region Form Callbacks

		private void DoMouseClick(object snder, MouseEventArgs e)
		{
			if (_isCreatingHuntZone)
			{
				//SKPoint converted = ConvertScreenToMap(new Point(e.Location.X, e.Location.Y), scale, mapLeft, mapTop);
				//IPCFootholdData closest = FindClosestFootholdToPoint(converted);
				_huntZonePoints.Add(new SKPoint(_currHoveredFoothold.x1, _currHoveredFoothold.y1));

				if (_huntZoneCreationState == 0)
				{
					_huntZoneCreationState = 1;
				}
				else if (_huntZoneCreationState == 1)
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
			if (_isCreatingHuntZone)
			{
				SKPoint converted = ConvertScreenToMap(new Point(e.Location.X, e.Location.Y), scale, mapLeft, mapTop);
				IPCFootholdData closest = FindClosestFootholdToPoint(converted);
				_currHoveredFoothold = closest;
			}
		}

		private void SkControl_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
		{
			var canvas = e.Surface.Canvas;
			canvas.Clear(_bgColor);

			canvas.Scale(scale);
			canvas.Translate(-mapLeft, -mapTop);

			// canvas.DrawRect(CreateRect(testX, testY, 32, 32), new SKPaint { Color = SKColors.Red });

			DrawMobs(canvas);
			DrawFootHolds(canvas);
			DrawPortals(canvas);
			DrawHuntZones(canvas);
			DrawPlayer(canvas);
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			_parent.IMapOpen = false;
			e.Cancel = true;
			this.Hide();
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

		#endregion
	}
}
