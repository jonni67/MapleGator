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
			this.panel1 = new System.Windows.Forms.Panel();
			this.logoImage = new System.Windows.Forms.PictureBox();
			this.buttonHook = new System.Windows.Forms.Button();
			this.processComboBox = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label5 = new System.Windows.Forms.Label();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.logoImage)).BeginInit();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(144)))), ((int)(((byte)(99)))));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.buttonHook);
			this.panel1.Controls.Add(this.processComboBox);
			this.panel1.Location = new System.Drawing.Point(13, 71);
			this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(164, 101);
			this.panel1.TabIndex = 7;
			// 
			// logoImage
			// 
			this.logoImage.Image = global::MapleGatorBot.Properties.Resources.ms_gator;
			this.logoImage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.logoImage.Location = new System.Drawing.Point(13, 12);
			this.logoImage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.logoImage.Name = "logoImage";
			this.logoImage.Size = new System.Drawing.Size(100, 31);
			this.logoImage.TabIndex = 0;
			this.logoImage.TabStop = false;
			// 
			// buttonHook
			// 
			this.buttonHook.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonHook.BackgroundImage")));
			this.buttonHook.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.buttonHook.FlatAppearance.BorderSize = 0;
			this.buttonHook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonHook.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonHook.ForeColor = System.Drawing.Color.Black;
			this.buttonHook.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.buttonHook.Location = new System.Drawing.Point(2, 30);
			this.buttonHook.Margin = new System.Windows.Forms.Padding(16);
			this.buttonHook.Name = "buttonHook";
			this.buttonHook.Size = new System.Drawing.Size(149, 25);
			this.buttonHook.TabIndex = 0;
			this.buttonHook.Text = "HOOK";
			this.buttonHook.UseVisualStyleBackColor = true;
			this.buttonHook.Click += new System.EventHandler(this.Btn_Hook_Click);
			// 
			// processComboBox
			// 
			this.processComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(90)))), ((int)(((byte)(76)))));
			this.processComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.processComboBox.FormattingEnabled = true;
			this.processComboBox.ItemHeight = 14;
			this.processComboBox.Location = new System.Drawing.Point(2, 65);
			this.processComboBox.Margin = new System.Windows.Forms.Padding(16);
			this.processComboBox.Name = "processComboBox";
			this.processComboBox.Size = new System.Drawing.Size(149, 22);
			this.processComboBox.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
			this.label2.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label2.Location = new System.Drawing.Point(267, 12);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(244, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "PROCESS NOT HOOKED";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(120, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(140, 23);
			this.label1.TabIndex = 8;
			this.label1.Text = "MAPLEGATOR";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(12, 47);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(175, 21);
			this.label3.TabIndex = 9;
			this.label3.Text = "Character: None";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.Cyan;
			this.label4.Location = new System.Drawing.Point(-1, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(128, 18);
			this.label4.TabIndex = 2;
			this.label4.Text = "PROCESS HOOK";
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(144)))), ((int)(((byte)(99)))));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.textBox3);
			this.panel2.Controls.Add(this.label8);
			this.panel2.Controls.Add(this.textBox2);
			this.panel2.Controls.Add(this.label7);
			this.panel2.Controls.Add(this.label6);
			this.panel2.Controls.Add(this.textBox1);
			this.panel2.Controls.Add(this.checkBox1);
			this.panel2.Controls.Add(this.label5);
			this.panel2.Location = new System.Drawing.Point(184, 71);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(209, 188);
			this.panel2.TabIndex = 10;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.Cyan;
			this.label5.Location = new System.Drawing.Point(-1, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(108, 18);
			this.label5.TabIndex = 0;
			this.label5.Text = "AUTO LOGIN";
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBox1.Location = new System.Drawing.Point(113, -1);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(97, 22);
			this.checkBox1.TabIndex = 1;
			this.checkBox1.Text = "ENABLED";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(90)))), ((int)(((byte)(76)))));
			this.textBox1.Location = new System.Drawing.Point(4, 51);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(128, 20);
			this.textBox1.TabIndex = 2;
			this.textBox1.WordWrap = false;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(8, 30);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(88, 18);
			this.label6.TabIndex = 3;
			this.label6.Text = "USERNAME";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(8, 82);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(88, 18);
			this.label7.TabIndex = 4;
			this.label7.Text = "PASSWORD";
			// 
			// textBox2
			// 
			this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(90)))), ((int)(((byte)(76)))));
			this.textBox2.Location = new System.Drawing.Point(4, 103);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(128, 20);
			this.textBox2.TabIndex = 5;
			this.textBox2.UseSystemPasswordChar = true;
			this.textBox2.WordWrap = false;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(8, 135);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(38, 18);
			this.label8.TabIndex = 6;
			this.label8.Text = "PIN";
			// 
			// textBox3
			// 
			this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(90)))), ((int)(((byte)(76)))));
			this.textBox3.Location = new System.Drawing.Point(4, 156);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(69, 20);
			this.textBox3.TabIndex = 7;
			this.textBox3.UseSystemPasswordChar = true;
			this.textBox3.WordWrap = false;
			// 
			// Primary
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(90)))), ((int)(((byte)(76)))));
			this.ClientSize = new System.Drawing.Size(928, 456);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.logoImage);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Primary";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Form1";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.logoImage)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox logoImage;
		private System.Windows.Forms.Button buttonHook;
		private System.Windows.Forms.ComboBox processComboBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textBox2;
	}
}