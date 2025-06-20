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
			this.pathfindingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip
			// 
			this.menuStrip.BackColor = System.Drawing.Color.Black;
			resources.ApplyResources(this.menuStrip, "menuStrip");
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenuItem,
            this.pathfindingMenuItem,
            this.propertiesToolStripMenuItem});
			this.menuStrip.Name = "menuStrip";
			// 
			// mainMenuItem
			// 
			this.mainMenuItem.ForeColor = System.Drawing.SystemColors.Control;
			this.mainMenuItem.Name = "mainMenuItem";
			resources.ApplyResources(this.mainMenuItem, "mainMenuItem");
			this.mainMenuItem.Click += new System.EventHandler(this.MenuItem_Main_Click);
			// 
			// pathfindingMenuItem
			// 
			this.pathfindingMenuItem.ForeColor = System.Drawing.SystemColors.Control;
			this.pathfindingMenuItem.Name = "pathfindingMenuItem";
			resources.ApplyResources(this.pathfindingMenuItem, "pathfindingMenuItem");
			this.pathfindingMenuItem.Click += new System.EventHandler(this.MenuItem_Pathfinding_Click);
			// 
			// propertiesToolStripMenuItem
			// 
			this.propertiesToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
			this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
			resources.ApplyResources(this.propertiesToolStripMenuItem, "propertiesToolStripMenuItem");
			// 
			// MapleGator
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.Controls.Add(this.menuStrip);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.menuStrip;
			this.MaximizeBox = false;
			this.Name = "MapleGator";
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
	}
}

