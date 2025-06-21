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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Primary));
			this.processPanel = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.buttonHook = new System.Windows.Forms.Button();
			this.processComboBox = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.autoLoginPanel = new System.Windows.Forms.Panel();
			this.autoLoginToggleLabel = new System.Windows.Forms.Label();
			this.buttonAutoLoginToggle = new System.Windows.Forms.Button();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.topPanel = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.logoImage = new System.Windows.Forms.PictureBox();
			this.statPanel = new System.Windows.Forms.Panel();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.statusPanel = new System.Windows.Forms.Panel();
			this.label15 = new System.Windows.Forms.Label();
			this.statusLabel = new System.Windows.Forms.Label();
			this.timerLabel = new System.Windows.Forms.Label();
			this.processPanel.SuspendLayout();
			this.autoLoginPanel.SuspendLayout();
			this.topPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.logoImage)).BeginInit();
			this.statPanel.SuspendLayout();
			this.statusPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// processPanel
			// 
			this.processPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(144)))), ((int)(((byte)(99)))));
			this.processPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.processPanel.CausesValidation = false;
			this.processPanel.Controls.Add(this.label2);
			this.processPanel.Controls.Add(this.label4);
			this.processPanel.Controls.Add(this.buttonHook);
			this.processPanel.Controls.Add(this.processComboBox);
			this.processPanel.Location = new System.Drawing.Point(16, 54);
			this.processPanel.Margin = new System.Windows.Forms.Padding(0);
			this.processPanel.Name = "processPanel";
			this.processPanel.Size = new System.Drawing.Size(176, 133);
			this.processPanel.TabIndex = 7;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Black;
			this.label2.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.label2.Location = new System.Drawing.Point(8, 103);
			this.label2.Margin = new System.Windows.Forms.Padding(8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(108, 18);
			this.label2.TabIndex = 13;
			this.label2.Text = "NOT HOOKED";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Black;
			this.label4.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.label4.Location = new System.Drawing.Point(8, 8);
			this.label4.Margin = new System.Windows.Forms.Padding(8);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(128, 18);
			this.label4.TabIndex = 2;
			this.label4.Text = "PROCESS HOOK";
			// 
			// buttonHook
			// 
			this.buttonHook.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.buttonHook.FlatAppearance.BorderColor = System.Drawing.Color.White;
			this.buttonHook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonHook.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonHook.ForeColor = System.Drawing.Color.White;
			this.buttonHook.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.buttonHook.Location = new System.Drawing.Point(8, 32);
			this.buttonHook.Margin = new System.Windows.Forms.Padding(8);
			this.buttonHook.Name = "buttonHook";
			this.buttonHook.Size = new System.Drawing.Size(149, 25);
			this.buttonHook.TabIndex = 0;
			this.buttonHook.Text = "HOOK";
			this.buttonHook.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
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
			this.processComboBox.Location = new System.Drawing.Point(8, 64);
			this.processComboBox.Margin = new System.Windows.Forms.Padding(8);
			this.processComboBox.Name = "processComboBox";
			this.processComboBox.Size = new System.Drawing.Size(150, 22);
			this.processComboBox.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Black;
			this.label3.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.label3.Location = new System.Drawing.Point(8, 8);
			this.label3.Margin = new System.Windows.Forms.Padding(8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(98, 18);
			this.label3.TabIndex = 9;
			this.label3.Text = "Character";
			// 
			// autoLoginPanel
			// 
			this.autoLoginPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(144)))), ((int)(((byte)(99)))));
			this.autoLoginPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.autoLoginPanel.CausesValidation = false;
			this.autoLoginPanel.Controls.Add(this.autoLoginToggleLabel);
			this.autoLoginPanel.Controls.Add(this.buttonAutoLoginToggle);
			this.autoLoginPanel.Controls.Add(this.textBox3);
			this.autoLoginPanel.Controls.Add(this.label8);
			this.autoLoginPanel.Controls.Add(this.textBox2);
			this.autoLoginPanel.Controls.Add(this.label7);
			this.autoLoginPanel.Controls.Add(this.label6);
			this.autoLoginPanel.Controls.Add(this.textBox1);
			this.autoLoginPanel.Controls.Add(this.label5);
			this.autoLoginPanel.Location = new System.Drawing.Point(203, 54);
			this.autoLoginPanel.Margin = new System.Windows.Forms.Padding(0);
			this.autoLoginPanel.Name = "autoLoginPanel";
			this.autoLoginPanel.Size = new System.Drawing.Size(209, 196);
			this.autoLoginPanel.TabIndex = 10;
			// 
			// autoLoginToggleLabel
			// 
			this.autoLoginToggleLabel.AutoSize = true;
			this.autoLoginToggleLabel.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.autoLoginToggleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.autoLoginToggleLabel.Location = new System.Drawing.Point(164, 48);
			this.autoLoginToggleLabel.Name = "autoLoginToggleLabel";
			this.autoLoginToggleLabel.Size = new System.Drawing.Size(38, 18);
			this.autoLoginToggleLabel.TabIndex = 9;
			this.autoLoginToggleLabel.Text = "OFF";
			// 
			// buttonAutoLoginToggle
			// 
			this.buttonAutoLoginToggle.BackColor = System.Drawing.Color.Black;
			this.buttonAutoLoginToggle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.buttonAutoLoginToggle.Cursor = System.Windows.Forms.Cursors.Default;
			this.buttonAutoLoginToggle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.buttonAutoLoginToggle.FlatAppearance.BorderSize = 2;
			this.buttonAutoLoginToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonAutoLoginToggle.ForeColor = System.Drawing.Color.Black;
			this.buttonAutoLoginToggle.Image = ((System.Drawing.Image)(resources.GetObject("buttonAutoLoginToggle.Image")));
			this.buttonAutoLoginToggle.Location = new System.Drawing.Point(167, 8);
			this.buttonAutoLoginToggle.Margin = new System.Windows.Forms.Padding(8);
			this.buttonAutoLoginToggle.Name = "buttonAutoLoginToggle";
			this.buttonAutoLoginToggle.Size = new System.Drawing.Size(32, 32);
			this.buttonAutoLoginToggle.TabIndex = 8;
			this.buttonAutoLoginToggle.UseVisualStyleBackColor = false;
			this.buttonAutoLoginToggle.Click += new System.EventHandler(this.Btn_AutoLoginToggle_Click);
			// 
			// textBox3
			// 
			this.textBox3.BackColor = System.Drawing.Color.Black;
			this.textBox3.ForeColor = System.Drawing.SystemColors.Control;
			this.textBox3.Location = new System.Drawing.Point(8, 168);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(69, 20);
			this.textBox3.TabIndex = 7;
			this.textBox3.UseSystemPasswordChar = true;
			this.textBox3.WordWrap = false;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.ForeColor = System.Drawing.SystemColors.Control;
			this.label8.Location = new System.Drawing.Point(8, 144);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(38, 18);
			this.label8.TabIndex = 6;
			this.label8.Text = "PIN";
			// 
			// textBox2
			// 
			this.textBox2.BackColor = System.Drawing.Color.Black;
			this.textBox2.ForeColor = System.Drawing.SystemColors.Control;
			this.textBox2.Location = new System.Drawing.Point(8, 112);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(128, 20);
			this.textBox2.TabIndex = 5;
			this.textBox2.UseSystemPasswordChar = true;
			this.textBox2.WordWrap = false;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.ForeColor = System.Drawing.SystemColors.Control;
			this.label7.Location = new System.Drawing.Point(8, 88);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(88, 18);
			this.label7.TabIndex = 4;
			this.label7.Text = "PASSWORD";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.ForeColor = System.Drawing.SystemColors.Control;
			this.label6.Location = new System.Drawing.Point(8, 32);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(88, 18);
			this.label6.TabIndex = 3;
			this.label6.Text = "USERNAME";
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.Color.Black;
			this.textBox1.ForeColor = System.Drawing.SystemColors.Control;
			this.textBox1.Location = new System.Drawing.Point(8, 56);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(128, 20);
			this.textBox1.TabIndex = 2;
			this.textBox1.WordWrap = false;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Black;
			this.label5.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.label5.Location = new System.Drawing.Point(8, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(108, 18);
			this.label5.TabIndex = 0;
			this.label5.Text = "AUTO LOGIN";
			// 
			// topPanel
			// 
			this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(144)))), ((int)(((byte)(99)))));
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
			this.label1.BackColor = System.Drawing.Color.Black;
			this.label1.Font = new System.Drawing.Font("Taurus Mono Outline", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.label1.Location = new System.Drawing.Point(5, 5);
			this.label1.Margin = new System.Windows.Forms.Padding(8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(172, 28);
			this.label1.TabIndex = 12;
			this.label1.Text = "MAPLEGATOR";
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
			this.label14.BackColor = System.Drawing.Color.Black;
			this.label14.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label14.ForeColor = System.Drawing.SystemColors.Control;
			this.label14.Location = new System.Drawing.Point(8, 168);
			this.label14.Margin = new System.Windows.Forms.Padding(8);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(49, 19);
			this.label14.TabIndex = 15;
			this.label14.Text = "NONE";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.BackColor = System.Drawing.Color.Black;
			this.label13.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.label13.Location = new System.Drawing.Point(8, 144);
			this.label13.Margin = new System.Windows.Forms.Padding(8);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(38, 18);
			this.label13.TabIndex = 14;
			this.label13.Text = "MAP";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.BackColor = System.Drawing.Color.Black;
			this.label12.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label12.ForeColor = System.Drawing.SystemColors.Control;
			this.label12.Location = new System.Drawing.Point(8, 112);
			this.label12.Margin = new System.Windows.Forms.Padding(8);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(49, 19);
			this.label12.TabIndex = 13;
			this.label12.Text = "Y: 0";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.BackColor = System.Drawing.Color.Black;
			this.label11.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.ForeColor = System.Drawing.SystemColors.Control;
			this.label11.Location = new System.Drawing.Point(8, 88);
			this.label11.Margin = new System.Windows.Forms.Padding(8);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(49, 19);
			this.label11.TabIndex = 12;
			this.label11.Text = "X: 0";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.BackColor = System.Drawing.Color.Black;
			this.label10.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.label10.Location = new System.Drawing.Point(8, 64);
			this.label10.Margin = new System.Windows.Forms.Padding(8);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(88, 18);
			this.label10.TabIndex = 11;
			this.label10.Text = "Position";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.BackColor = System.Drawing.Color.Black;
			this.label9.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.ForeColor = System.Drawing.SystemColors.Control;
			this.label9.Location = new System.Drawing.Point(8, 32);
			this.label9.Margin = new System.Windows.Forms.Padding(8);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(49, 19);
			this.label9.TabIndex = 10;
			this.label9.Text = "NONE";
			// 
			// statusPanel
			// 
			this.statusPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(144)))), ((int)(((byte)(99)))));
			this.statusPanel.Controls.Add(this.timerLabel);
			this.statusPanel.Controls.Add(this.statusLabel);
			this.statusPanel.Controls.Add(this.label15);
			this.statusPanel.Location = new System.Drawing.Point(203, 262);
			this.statusPanel.Name = "statusPanel";
			this.statusPanel.Size = new System.Drawing.Size(209, 161);
			this.statusPanel.TabIndex = 13;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.BackColor = System.Drawing.Color.Black;
			this.label15.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.label15.Location = new System.Drawing.Point(8, 8);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(68, 18);
			this.label15.TabIndex = 10;
			this.label15.Text = "STATUS";
			// 
			// statusLabel
			// 
			this.statusLabel.AutoSize = true;
			this.statusLabel.BackColor = System.Drawing.Color.Black;
			this.statusLabel.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.statusLabel.ForeColor = System.Drawing.SystemColors.Control;
			this.statusLabel.Location = new System.Drawing.Point(8, 32);
			this.statusLabel.Margin = new System.Windows.Forms.Padding(8);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(49, 19);
			this.statusLabel.TabIndex = 16;
			this.statusLabel.Text = "NONE";
			// 
			// timerLabel
			// 
			this.timerLabel.AutoSize = true;
			this.timerLabel.BackColor = System.Drawing.Color.Black;
			this.timerLabel.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.timerLabel.ForeColor = System.Drawing.SystemColors.Control;
			this.timerLabel.Location = new System.Drawing.Point(8, 56);
			this.timerLabel.Margin = new System.Windows.Forms.Padding(8);
			this.timerLabel.Name = "timerLabel";
			this.timerLabel.Size = new System.Drawing.Size(128, 18);
			this.timerLabel.TabIndex = 17;
			this.timerLabel.Text = "0.0 Sec Left";
			// 
			// Primary
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.CausesValidation = false;
			this.ClientSize = new System.Drawing.Size(929, 457);
			this.Controls.Add(this.statusPanel);
			this.Controls.Add(this.statPanel);
			this.Controls.Add(this.logoImage);
			this.Controls.Add(this.topPanel);
			this.Controls.Add(this.autoLoginPanel);
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
			this.autoLoginPanel.ResumeLayout(false);
			this.autoLoginPanel.PerformLayout();
			this.topPanel.ResumeLayout(false);
			this.topPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.logoImage)).EndInit();
			this.statPanel.ResumeLayout(false);
			this.statPanel.PerformLayout();
			this.statusPanel.ResumeLayout(false);
			this.statusPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel processPanel;
		private System.Windows.Forms.PictureBox logoImage;
		private System.Windows.Forms.Button buttonHook;
		private System.Windows.Forms.ComboBox processComboBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel autoLoginPanel;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button buttonAutoLoginToggle;
		private System.Windows.Forms.Label autoLoginToggleLabel;
		private System.Windows.Forms.Panel topPanel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
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
	}
}