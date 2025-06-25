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

		IMapDrawModes _drawMode;

		public InteractiveMap(MapleGator parent)
		{
			_parent = parent;
			InitializeComponent();

			_drawPoints.Add(new Point(0, 64));
			_drawPoints.Add(new Point(128, 64));
			_drawPoints.Add(new Point(128, 128));

			_drawPoints.Add(new Point(256, 128));

			this.MouseDown += StartDragDraw;

			this.MouseUp += FinishDragDraw;

			this.MouseMove += UpdateDragDraw;

			/*
			this.MouseMove += (s, e) =>
			{
				if (isDrawing)
				{
					drawPoints.Add(e.Location);
					this.Invalidate();
				}
			};
			*/

			this.Paint += IPaint;

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
			if (_drawPoints.Count > 1)
			{
				g.DrawLines(Pens.White, _drawPoints.ToArray());
			}

			g.DrawRectangle(Pens.Green, _currHuntZoneDraw);

			for (int i = 0; i < _huntZones.Count; i++)
			{
				g.DrawRectangle(Pens.Green, _huntZones[i]);
			}

			this.Invalidate();
		}
	}
}
