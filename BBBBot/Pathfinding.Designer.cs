namespace MapleGatorBot
{
	partial class Pathfinding
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
			this.button1 = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(9, 63);
			this.button1.Margin = new System.Windows.Forms.Padding(0);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(173, 152);
			this.button1.TabIndex = 0;
			this.button1.Text = "FORM TEST";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::MapleGatorBot.Properties.Resources.ms_gator;
			this.pictureBox1.Location = new System.Drawing.Point(9, 9);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(117, 54);
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// Pathfinding
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.CausesValidation = false;
			this.ClientSize = new System.Drawing.Size(748, 445);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.button1);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Pathfinding";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Pathfinding";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}