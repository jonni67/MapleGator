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
		List<Point> _drawPoints = new List<Point>();
		List<SKRect> _huntZones = new List<SKRect>();

		Point _huntZoneStart = new Point();
		SKRect _currHuntZoneDraw = new SKRect();

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

		bool scaled = false;

		List<PointF> _screenHuntPoints = new List<PointF>();
		List<PointF> _worldHuntPoints = new List<PointF>();

		IMapDrawModes _drawMode;

		public InteractiveMap(MapleGator parent)
		{
			_parent = parent;
			InitializeComponent();

			skControl = new SKControl
			{
				Dock = DockStyle.Fill
			};

			skControl.PaintSurface += SkControl_PaintSurface;
			this.Controls.Add(skControl);

			// Optional: timer to refresh
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

			this.SetStyle(ControlStyles.AllPaintingInWmPaint |
				  ControlStyles.OptimizedDoubleBuffer |
				  ControlStyles.UserPaint, true);
			this.DoubleBuffered = true;
			this.UpdateStyles();

			skControl.MouseDown += StartDragDraw;
			skControl.MouseUp += FinishDragDraw;
			skControl.MouseMove += UpdateDragDraw;

			//this.Paint += IPaint;

			/*
			Timer timer = new Timer();
			timer.Interval = 1;
			timer.Tick += (s, e) =>
			{
				//this.Invalidate(); // Marks it for repaint
				//this.Update();     // Forces the repaint now
			};
			timer.Start();
			*/

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

		private void StartDragDraw(object snder, MouseEventArgs e)
		{
			if (_isDrawing)
				return;

			if(_drawMode == IMapDrawModes.HuntRectangle)
			{
				_isDrawing = true;
				_huntZoneStart = e.Location;
			}
		}

		private void UpdateDragDraw(object snder, MouseEventArgs e)
		{
			if (!_isDrawing)
				return;

			int xDiff = Math.Abs(_huntZoneStart.X - e.Location.X);
			int yDiff = Math.Abs(_huntZoneStart.Y - e.Location.Y);

			PointF converted = ConvertScreenToMap(new Point(_huntZoneStart.X, _huntZoneStart.Y), scale, mapLeft, mapTop);
			Console.WriteLine(converted);

			_currHuntZoneDraw = CreateRect((int)converted.X, (int)converted.Y, xDiff, yDiff);
		}

		private void FinishDragDraw(object snder, MouseEventArgs e)
		{
			if (!_isDrawing)
				return;

			if (_drawMode == IMapDrawModes.HuntRectangle)
			{
				float centerX = _currHuntZoneDraw.Left + (_currHuntZoneDraw.Width / 2);
				float centerY = _currHuntZoneDraw.Top + (_currHuntZoneDraw.Height / 2);
				_screenHuntPoints.Add(new PointF(centerX, centerY));
				_huntZones.Add(_currHuntZoneDraw);
				_isDrawing = false;
			}
		}

		private void SkControl_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
		{
			var canvas = e.Surface.Canvas;
			canvas.Clear(SKColors.Black);

			canvas.Scale(scale);
			canvas.Translate(-mapLeft, -mapTop);

			canvas.DrawRect(_currHuntZoneDraw, new SKPaint { Color = SKColors.Green });

			for (int i = 0; i < _huntZones.Count; i++)
			{
				canvas.DrawRect(_huntZones[i], new SKPaint { Color = SKColors.Green });
			}

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
			}

			// You'd compute this from your map logic
			//canvas.DrawCircle(200, 200, 10, entityPaint);
		}

		/*
		private void IPaint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			
			//g.ScaleTransform(scale, scale);
			//g.TranslateTransform(-mapLeft, -mapTop);
		
			g.Transform = _screenMatrix;

			g.DrawRectangle(Pens.Green, _currHuntZoneDraw);

			for (int i = 0; i < _huntZones.Count; i++)
			{
				g.DrawRectangle(Pens.Green, _huntZones[i]);
			}

			for (int i = 0; i < IPCManager.GAME_DATA.totalMobs; i++)
			{
				//Console.WriteLine($"[Mob {i}] (X: {_currArrayData.mobs[i].x}, Y: {_currArrayData.mobs[i].y})");
				//Console.WriteLine($"[Mob {i}] (X: {IPCManager.ARRAY_DATA.mobs[i].x}, Y: {IPCManager.ARRAY_DATA.mobs[i].y})");
				int x = (IPCManager.ARRAY_DATA.mobs[i].x) - 32;
				int y = (IPCManager.ARRAY_DATA.mobs[i].y) - 32;
				g.DrawRectangle(Pens.Red, new Rectangle(x, y, 32, 32));
			}
			
			for(int i = 0; i < IPCManager.GAME_DATA.totalFootholds; i++)
			{
				IPCFootholdData d = IPCManager.ARRAY_DATA.footholds[i];
				g.DrawLine(Pens.White, d.x1, d.y1, d.x2, d.y2);
			}
		}
		*/

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
	}
}
