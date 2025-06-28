using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapleGatorBot
{
	public partial class InteractiveMap : Form
	{
		MapleGator _parent;

		bool _isDrawing = false;
		List<Point> _drawPoints = new List<Point>();
		List<Rectangle> _huntZones = new List<Rectangle>();

		Point _huntZoneStart = new Point();
		Rectangle _currHuntZoneDraw = new Rectangle();

		float scalar = 0.5f;
		int xOff = 0;
		int yOff = -512;

		IMapDrawModes _drawMode;

		public InteractiveMap(MapleGator parent)
		{
			_parent = parent;
			InitializeComponent();

			this.MouseDown += StartDragDraw;
			this.MouseUp += FinishDragDraw;
			this.MouseMove += UpdateDragDraw;
			this.Paint += IPaint;

			Timer timer = new Timer();
			timer.Interval = 100;
			timer.Tick += (s, e) =>
			{
				this.Invalidate(); // Marks it for repaint
				this.Update();     // Forces the repaint now
			};
			timer.Start();

			_drawMode = IMapDrawModes.HuntRectangle;
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

			_currHuntZoneDraw = new Rectangle(_huntZoneStart.X, _huntZoneStart.Y, xDiff, yDiff);
		}

		private void FinishDragDraw(object snder, MouseEventArgs e)
		{
			if (!_isDrawing)
				return;

			if (_drawMode == IMapDrawModes.HuntRectangle)
			{
				_huntZones.Add(_currHuntZoneDraw);
				_isDrawing = false;
				this.Invalidate();
			}
		}

		private void IPaint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;

			g.DrawRectangle(Pens.Green, _currHuntZoneDraw);

			for (int i = 0; i < _huntZones.Count; i++)
			{
				g.DrawRectangle(Pens.Green, _huntZones[i]);
			}

			
			for (int i = 0; i < IPCManager.GAME_DATA.totalMobs; i++)
			{
				//Console.WriteLine($"[Mob {i}] (X: {_currArrayData.mobs[i].x}, Y: {_currArrayData.mobs[i].y})");
				//Console.WriteLine($"[Mob {i}] (X: {IPCManager.ARRAY_DATA.mobs[i].x}, Y: {IPCManager.ARRAY_DATA.mobs[i].y})");
				int x = (int)((IPCManager.ARRAY_DATA.mobs[i].x - xOff) * scalar) + 16;
				int y = (int)((IPCManager.ARRAY_DATA.mobs[i].y - yOff) * scalar) - 16;
				g.DrawRectangle(Pens.Red, new Rectangle(x, y, 32, 32));
			}
			

			for(int i = 0; i < IPCManager.GAME_DATA.totalFootholds; i++)
			{
				IPCFootholdData d = IPCManager.ARRAY_DATA.footholds[i];
				int x1 = (int)((d.x1 - xOff) * scalar);
				int y1 = (int)((d.y1 - yOff) * scalar);
				int x2 = (int)((d.x2 - xOff) * scalar);
				int y2 = (int)((d.y2 - yOff) * scalar);

				g.DrawLine(Pens.White, x1, y1, x2, y2);
			}
		}
	}
}
