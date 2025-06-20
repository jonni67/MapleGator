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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.mainMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pathfindingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(90)))), ((int)(((byte)(76)))));
			resources.ApplyResources(this.menuStrip1, "menuStrip1");
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenuItem,
            this.pathfindingMenuItem,
            this.propertiesToolStripMenuItem});
			this.menuStrip1.Name = "menuStrip1";
			// 
			// mainMenuItem
			// 
			this.mainMenuItem.Name = "mainMenuItem";
			resources.ApplyResources(this.mainMenuItem, "mainMenuItem");
			this.mainMenuItem.Click += new System.EventHandler(this.MenuItem_Main_Click);
			// 
			// pathfindingMenuItem
			// 
			this.pathfindingMenuItem.Name = "pathfindingMenuItem";
			resources.ApplyResources(this.pathfindingMenuItem, "pathfindingMenuItem");
			this.pathfindingMenuItem.Click += new System.EventHandler(this.MenuItem_Pathfinding_Click);
			// 
			// propertiesToolStripMenuItem
			// 
			this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
			resources.ApplyResources(this.propertiesToolStripMenuItem, "propertiesToolStripMenuItem");
			// 
			// MapleGator
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(90)))), ((int)(((byte)(76)))));
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "MapleGator";
			this.Load += new System.EventHandler(this.MapleGator_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mainMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pathfindingMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
	}
}

