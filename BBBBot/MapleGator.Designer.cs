namespace MapleGatorBot
{
    partial class MapleGator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapleGator));
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.mainMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.autoLoginMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pathfindingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.interactiveMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1 = new System.Windows.Forms.Panel();
			this.menuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip
			// 
			this.menuStrip.BackColor = System.Drawing.Color.Black;
			this.menuStrip.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.menuStrip.GripMargin = new System.Windows.Forms.Padding(0);
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenuItem,
            this.autoLoginMenuItem,
            this.pathfindingMenuItem,
            this.interactiveMapToolStripMenuItem,
            this.propertiesToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Padding = new System.Windows.Forms.Padding(0);
			this.menuStrip.Size = new System.Drawing.Size(752, 24);
			this.menuStrip.TabIndex = 2;
			this.menuStrip.Text = "menuStrip";
			// 
			// mainMenuItem
			// 
			this.mainMenuItem.ForeColor = System.Drawing.SystemColors.Control;
			this.mainMenuItem.Name = "mainMenuItem";
			this.mainMenuItem.Size = new System.Drawing.Size(47, 24);
			this.mainMenuItem.Text = "Main";
			this.mainMenuItem.Click += new System.EventHandler(this.MenuItem_Main_Click);
			// 
			// autoLoginMenuItem
			// 
			this.autoLoginMenuItem.ForeColor = System.Drawing.SystemColors.Control;
			this.autoLoginMenuItem.Name = "autoLoginMenuItem";
			this.autoLoginMenuItem.Size = new System.Drawing.Size(76, 24);
			this.autoLoginMenuItem.Text = "Auto Login";
			this.autoLoginMenuItem.Click += new System.EventHandler(this.MenuItem_AutoLogin_Click);
			// 
			// pathfindingMenuItem
			// 
			this.pathfindingMenuItem.ForeColor = System.Drawing.SystemColors.Control;
			this.pathfindingMenuItem.Name = "pathfindingMenuItem";
			this.pathfindingMenuItem.Size = new System.Drawing.Size(64, 24);
			this.pathfindingMenuItem.Text = "Planner";
			this.pathfindingMenuItem.Click += new System.EventHandler(this.MenuItem_Pathfinding_Click);
			// 
			// propertiesToolStripMenuItem
			// 
			this.propertiesToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
			this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
			this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
			this.propertiesToolStripMenuItem.Text = "Metrics";
			// 
			// interactiveMapToolStripMenuItem
			// 
			this.interactiveMapToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
			this.interactiveMapToolStripMenuItem.Name = "interactiveMapToolStripMenuItem";
			this.interactiveMapToolStripMenuItem.Size = new System.Drawing.Size(103, 24);
			this.interactiveMapToolStripMenuItem.Text = "Interactive Map";
			this.interactiveMapToolStripMenuItem.Click += new System.EventHandler(this.MenuItem_IMap_Click);
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(0, 24);
			this.panel1.Margin = new System.Windows.Forms.Padding(0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(752, 450);
			this.panel1.TabIndex = 4;
			this.panel1.Visible = false;
			// 
			// MapleGator
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Black;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.ClientSize = new System.Drawing.Size(752, 473);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.menuStrip);
			this.Font = new System.Drawing.Font("Courier New", 8.25F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.menuStrip;
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.MaximizeBox = false;
			this.Name = "MapleGator";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MapleGator";
			this.Load += new System.EventHandler(this.MapleGator_Load);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem mainMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pathfindingMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ToolStripMenuItem autoLoginMenuItem;
		private System.Windows.Forms.ToolStripMenuItem interactiveMapToolStripMenuItem;
	}
}

