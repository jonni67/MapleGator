namespace MapleGatorBot
{
	partial class InteractiveMap
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InteractiveMap));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.huntZoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.button1 = new System.Windows.Forms.Button();
			this.infoLabel = new System.Windows.Forms.Label();
			this.toggleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mobsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.portalsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.playerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dropsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.toggleToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// addToolStripMenuItem
			// 
			this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.huntZoneToolStripMenuItem});
			this.addToolStripMenuItem.Name = "addToolStripMenuItem";
			this.addToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
			this.addToolStripMenuItem.Text = "Add";
			// 
			// huntZoneToolStripMenuItem
			// 
			this.huntZoneToolStripMenuItem.Name = "huntZoneToolStripMenuItem";
			this.huntZoneToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
			this.huntZoneToolStripMenuItem.Text = "Hunt Zone";
			this.huntZoneToolStripMenuItem.Click += new System.EventHandler(this.huntZoneToolStripMenuItem_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(921, 27);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// infoLabel
			// 
			this.infoLabel.AutoSize = true;
			this.infoLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.infoLabel.ForeColor = System.Drawing.SystemColors.Control;
			this.infoLabel.Location = new System.Drawing.Point(13, 36);
			this.infoLabel.Name = "infoLabel";
			this.infoLabel.Size = new System.Drawing.Size(212, 23);
			this.infoLabel.TabIndex = 2;
			this.infoLabel.Text = "Use the menu to add new zones.";
			// 
			// toggleToolStripMenuItem
			// 
			this.toggleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mobsToolStripMenuItem,
            this.portalsToolStripMenuItem,
            this.playerToolStripMenuItem,
            this.dropsToolStripMenuItem});
			this.toggleToolStripMenuItem.Name = "toggleToolStripMenuItem";
			this.toggleToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
			this.toggleToolStripMenuItem.Text = "Toggle";
			// 
			// mobsToolStripMenuItem
			// 
			this.mobsToolStripMenuItem.Name = "mobsToolStripMenuItem";
			this.mobsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.mobsToolStripMenuItem.Text = "Mobs";
			// 
			// portalsToolStripMenuItem
			// 
			this.portalsToolStripMenuItem.Name = "portalsToolStripMenuItem";
			this.portalsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.portalsToolStripMenuItem.Text = "Portals";
			// 
			// playerToolStripMenuItem
			// 
			this.playerToolStripMenuItem.Name = "playerToolStripMenuItem";
			this.playerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.playerToolStripMenuItem.Text = "Player";
			// 
			// dropsToolStripMenuItem
			// 
			this.dropsToolStripMenuItem.Name = "dropsToolStripMenuItem";
			this.dropsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.dropsToolStripMenuItem.Text = "Drops";
			// 
			// InteractiveMap
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(1008, 729);
			this.Controls.Add(this.infoLabel);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.menuStrip1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "InteractiveMap";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "InteractiveMap";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem huntZoneToolStripMenuItem;
		private System.Windows.Forms.Label infoLabel;
		private System.Windows.Forms.ToolStripMenuItem toggleToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mobsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem portalsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem playerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem dropsToolStripMenuItem;
	}
}