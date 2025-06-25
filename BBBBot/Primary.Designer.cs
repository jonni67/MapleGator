namespace MapleGatorBot
{
	partial class Primary
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
			this.processPanel = new System.Windows.Forms.Panel();
			this.hookedLabel = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.buttonHook = new System.Windows.Forms.Button();
			this.processComboBox = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.topPanel = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.statPanel = new System.Windows.Forms.Panel();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.statusPanel = new System.Windows.Forms.Panel();
			this.timerLabel = new System.Windows.Forms.Label();
			this.statusLabel = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.settingsPanel = new System.Windows.Forms.Panel();
			this.label16 = new System.Windows.Forms.Label();
			this.SettingsUpdateRate = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.logoImage = new System.Windows.Forms.PictureBox();
			this.processPanel.SuspendLayout();
			this.topPanel.SuspendLayout();
			this.statPanel.SuspendLayout();
			this.statusPanel.SuspendLayout();
			this.settingsPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.logoImage)).BeginInit();
			this.SuspendLayout();
			// 
			// processPanel
			// 
			this.processPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(144)))), ((int)(((byte)(99)))));
			this.processPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.processPanel.CausesValidation = false;
			this.processPanel.Controls.Add(this.buttonHook);
			this.processPanel.Controls.Add(this.hookedLabel);
			this.processPanel.Controls.Add(this.label4);
			this.processPanel.Controls.Add(this.processComboBox);
			this.processPanel.Location = new System.Drawing.Point(16, 54);
			this.processPanel.Margin = new System.Windows.Forms.Padding(0);
			this.processPanel.Name = "processPanel";
			this.processPanel.Size = new System.Drawing.Size(176, 133);
			this.processPanel.TabIndex = 7;
			// 
			// hookedLabel
			// 
			this.hookedLabel.AutoSize = true;
			this.hookedLabel.BackColor = System.Drawing.Color.Transparent;
			this.hookedLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.hookedLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.hookedLabel.Location = new System.Drawing.Point(4, 104);
			this.hookedLabel.Margin = new System.Windows.Forms.Padding(8);
			this.hookedLabel.Name = "hookedLabel";
			this.hookedLabel.Size = new System.Drawing.Size(73, 19);
			this.hookedLabel.TabIndex = 13;
			this.hookedLabel.Text = "NOT HOOKED";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.label4.Location = new System.Drawing.Point(8, 8);
			this.label4.Margin = new System.Windows.Forms.Padding(8);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(105, 23);
			this.label4.TabIndex = 2;
			this.label4.Text = "PROCESS HOOK";
			// 
			// buttonHook
			// 
			this.buttonHook.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.buttonHook.FlatAppearance.BorderColor = System.Drawing.Color.White;
			this.buttonHook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonHook.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonHook.ForeColor = System.Drawing.Color.White;
			this.buttonHook.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonHook.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.buttonHook.Location = new System.Drawing.Point(9, 41);
			this.buttonHook.Margin = new System.Windows.Forms.Padding(8);
			this.buttonHook.Name = "buttonHook";
			this.buttonHook.Size = new System.Drawing.Size(149, 35);
			this.buttonHook.TabIndex = 0;
			this.buttonHook.Text = "HOOK";
			this.buttonHook.UseVisualStyleBackColor = true;
			this.buttonHook.Click += new System.EventHandler(this.Btn_Hook_Click);
			// 
			// processComboBox
			// 
			this.processComboBox.BackColor = System.Drawing.Color.Black;
			this.processComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.processComboBox.ForeColor = System.Drawing.Color.Cyan;
			this.processComboBox.FormattingEnabled = true;
			this.processComboBox.ItemHeight = 14;
			this.processComboBox.Location = new System.Drawing.Point(8, 83);
			this.processComboBox.Margin = new System.Windows.Forms.Padding(8);
			this.processComboBox.Name = "processComboBox";
			this.processComboBox.Size = new System.Drawing.Size(150, 22);
			this.processComboBox.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.label3.Location = new System.Drawing.Point(8, 8);
			this.label3.Margin = new System.Windows.Forms.Padding(8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(63, 19);
			this.label3.TabIndex = 9;
			this.label3.Text = "Character";
			// 
			// topPanel
			// 
			this.topPanel.BackColor = System.Drawing.Color.Transparent;
			this.topPanel.Controls.Add(this.label1);
			this.topPanel.Location = new System.Drawing.Point(120, 12);
			this.topPanel.Margin = new System.Windows.Forms.Padding(0);
			this.topPanel.Name = "topPanel";
			this.topPanel.Size = new System.Drawing.Size(797, 31);
			this.topPanel.TabIndex = 11;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.label1.Location = new System.Drawing.Point(5, 5);
			this.label1.Margin = new System.Windows.Forms.Padding(8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(91, 23);
			this.label1.TabIndex = 12;
			this.label1.Text = "MAPLEGATOR";
			// 
			// statPanel
			// 
			this.statPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(144)))), ((int)(((byte)(99)))));
			this.statPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.statPanel.CausesValidation = false;
			this.statPanel.Controls.Add(this.label14);
			this.statPanel.Controls.Add(this.label13);
			this.statPanel.Controls.Add(this.label12);
			this.statPanel.Controls.Add(this.label11);
			this.statPanel.Controls.Add(this.label10);
			this.statPanel.Controls.Add(this.label9);
			this.statPanel.Controls.Add(this.label3);
			this.statPanel.Location = new System.Drawing.Point(16, 199);
			this.statPanel.Margin = new System.Windows.Forms.Padding(0);
			this.statPanel.Name = "statPanel";
			this.statPanel.Size = new System.Drawing.Size(176, 224);
			this.statPanel.TabIndex = 12;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.BackColor = System.Drawing.Color.Transparent;
			this.label14.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label14.ForeColor = System.Drawing.SystemColors.Control;
			this.label14.Location = new System.Drawing.Point(8, 168);
			this.label14.Margin = new System.Windows.Forms.Padding(8);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(36, 19);
			this.label14.TabIndex = 15;
			this.label14.Text = "NONE";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.BackColor = System.Drawing.Color.Transparent;
			this.label13.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.label13.Location = new System.Drawing.Point(8, 144);
			this.label13.Margin = new System.Windows.Forms.Padding(8);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(32, 19);
			this.label13.TabIndex = 14;
			this.label13.Text = "MAP";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.BackColor = System.Drawing.Color.Transparent;
			this.label12.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label12.ForeColor = System.Drawing.SystemColors.Control;
			this.label12.Location = new System.Drawing.Point(8, 112);
			this.label12.Margin = new System.Windows.Forms.Padding(8);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(27, 19);
			this.label12.TabIndex = 13;
			this.label12.Text = "Y: 0";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.BackColor = System.Drawing.Color.Transparent;
			this.label11.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.ForeColor = System.Drawing.SystemColors.Control;
			this.label11.Location = new System.Drawing.Point(8, 88);
			this.label11.Margin = new System.Windows.Forms.Padding(8);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(29, 19);
			this.label11.TabIndex = 12;
			this.label11.Text = "X: 0";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.BackColor = System.Drawing.Color.Transparent;
			this.label10.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.label10.Location = new System.Drawing.Point(8, 64);
			this.label10.Margin = new System.Windows.Forms.Padding(8);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(50, 19);
			this.label10.TabIndex = 11;
			this.label10.Text = "Position";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.BackColor = System.Drawing.Color.Transparent;
			this.label9.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.ForeColor = System.Drawing.SystemColors.Control;
			this.label9.Location = new System.Drawing.Point(8, 32);
			this.label9.Margin = new System.Windows.Forms.Padding(8);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(36, 19);
			this.label9.TabIndex = 10;
			this.label9.Text = "NONE";
			// 
			// statusPanel
			// 
			this.statusPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(144)))), ((int)(((byte)(99)))));
			this.statusPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.statusPanel.Controls.Add(this.timerLabel);
			this.statusPanel.Controls.Add(this.statusLabel);
			this.statusPanel.Controls.Add(this.label15);
			this.statusPanel.Location = new System.Drawing.Point(203, 262);
			this.statusPanel.Name = "statusPanel";
			this.statusPanel.Size = new System.Drawing.Size(209, 161);
			this.statusPanel.TabIndex = 13;
			// 
			// timerLabel
			// 
			this.timerLabel.AutoSize = true;
			this.timerLabel.BackColor = System.Drawing.Color.Black;
			this.timerLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.timerLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.timerLabel.ForeColor = System.Drawing.SystemColors.Control;
			this.timerLabel.Location = new System.Drawing.Point(8, 136);
			this.timerLabel.Margin = new System.Windows.Forms.Padding(8);
			this.timerLabel.Name = "timerLabel";
			this.timerLabel.Size = new System.Drawing.Size(34, 21);
			this.timerLabel.TabIndex = 17;
			this.timerLabel.Text = "0.0s";
			// 
			// statusLabel
			// 
			this.statusLabel.BackColor = System.Drawing.Color.Black;
			this.statusLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.statusLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.statusLabel.ForeColor = System.Drawing.SystemColors.Control;
			this.statusLabel.Location = new System.Drawing.Point(8, 32);
			this.statusLabel.Margin = new System.Windows.Forms.Padding(8);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(191, 92);
			this.statusLabel.TabIndex = 16;
			this.statusLabel.Text = "NONE";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.BackColor = System.Drawing.Color.Transparent;
			this.label15.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.label15.Location = new System.Drawing.Point(8, 8);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(56, 23);
			this.label15.TabIndex = 10;
			this.label15.Text = "STATUS";
			// 
			// settingsPanel
			// 
			this.settingsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(144)))), ((int)(((byte)(99)))));
			this.settingsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.settingsPanel.Controls.Add(this.label16);
			this.settingsPanel.Controls.Add(this.SettingsUpdateRate);
			this.settingsPanel.Controls.Add(this.label2);
			this.settingsPanel.Location = new System.Drawing.Point(203, 54);
			this.settingsPanel.Name = "settingsPanel";
			this.settingsPanel.Size = new System.Drawing.Size(209, 196);
			this.settingsPanel.TabIndex = 14;
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label16.ForeColor = System.Drawing.SystemColors.Control;
			this.label16.Location = new System.Drawing.Point(8, 32);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(105, 19);
			this.label16.TabIndex = 10;
			this.label16.Text = "UPDATE RATE (ms)";
			// 
			// SettingsUpdateRate
			// 
			this.SettingsUpdateRate.BackColor = System.Drawing.Color.Black;
			this.SettingsUpdateRate.ForeColor = System.Drawing.SystemColors.Control;
			this.SettingsUpdateRate.Location = new System.Drawing.Point(11, 56);
			this.SettingsUpdateRate.Name = "SettingsUpdateRate";
			this.SettingsUpdateRate.Size = new System.Drawing.Size(100, 20);
			this.SettingsUpdateRate.TabIndex = 11;
			this.SettingsUpdateRate.TextChanged += new System.EventHandler(this.SettingsUpdateRate_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.label2.Location = new System.Drawing.Point(8, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(68, 23);
			this.label2.TabIndex = 10;
			this.label2.Text = "SETTINGS";
			// 
			// logoImage
			// 
			this.logoImage.Image = global::MapleGatorBot.Properties.Resources.ms_gator;
			this.logoImage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.logoImage.Location = new System.Drawing.Point(13, 12);
			this.logoImage.Margin = new System.Windows.Forms.Padding(0);
			this.logoImage.Name = "logoImage";
			this.logoImage.Size = new System.Drawing.Size(100, 31);
			this.logoImage.TabIndex = 0;
			this.logoImage.TabStop = false;
			this.logoImage.WaitOnLoad = true;
			// 
			// Primary
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Black;
			this.CausesValidation = false;
			this.ClientSize = new System.Drawing.Size(748, 445);
			this.Controls.Add(this.settingsPanel);
			this.Controls.Add(this.statusPanel);
			this.Controls.Add(this.statPanel);
			this.Controls.Add(this.logoImage);
			this.Controls.Add(this.topPanel);
			this.Controls.Add(this.processPanel);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.Red;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Primary";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Primary";
			this.processPanel.ResumeLayout(false);
			this.processPanel.PerformLayout();
			this.topPanel.ResumeLayout(false);
			this.topPanel.PerformLayout();
			this.statPanel.ResumeLayout(false);
			this.statPanel.PerformLayout();
			this.statusPanel.ResumeLayout(false);
			this.statusPanel.PerformLayout();
			this.settingsPanel.ResumeLayout(false);
			this.settingsPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.logoImage)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel processPanel;
		private System.Windows.Forms.PictureBox logoImage;
		private System.Windows.Forms.Button buttonHook;
		private System.Windows.Forms.ComboBox processComboBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel topPanel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label hookedLabel;
		private System.Windows.Forms.Panel statPanel;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Panel statusPanel;
		private System.Windows.Forms.Label statusLabel;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label timerLabel;
		private System.Windows.Forms.Panel settingsPanel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox SettingsUpdateRate;
	}
}