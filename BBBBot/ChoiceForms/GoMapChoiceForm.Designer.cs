namespace MapleGatorBot.ChoiceForms
{
	partial class GoMapChoiceForm
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
			this.cancelBtn = new System.Windows.Forms.Button();
			this.okBtn = new System.Windows.Forms.Button();
			this.valueTextBox = new System.Windows.Forms.TextBox();
			this.mainLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// cancelBtn
			// 
			this.cancelBtn.BackColor = System.Drawing.Color.Transparent;
			this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cancelBtn.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cancelBtn.ForeColor = System.Drawing.SystemColors.Control;
			this.cancelBtn.Location = new System.Drawing.Point(101, 89);
			this.cancelBtn.Margin = new System.Windows.Forms.Padding(8);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(88, 64);
			this.cancelBtn.TabIndex = 11;
			this.cancelBtn.Text = "CANCEL";
			this.cancelBtn.UseVisualStyleBackColor = false;
			this.cancelBtn.Click += new System.EventHandler(this.Btn_Cancel_Click);
			// 
			// okBtn
			// 
			this.okBtn.BackColor = System.Drawing.Color.Transparent;
			this.okBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.okBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.okBtn.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.okBtn.ForeColor = System.Drawing.SystemColors.Control;
			this.okBtn.Location = new System.Drawing.Point(21, 89);
			this.okBtn.Margin = new System.Windows.Forms.Padding(8);
			this.okBtn.Name = "okBtn";
			this.okBtn.Size = new System.Drawing.Size(64, 64);
			this.okBtn.TabIndex = 10;
			this.okBtn.Text = "OK";
			this.okBtn.UseVisualStyleBackColor = false;
			this.okBtn.Click += new System.EventHandler(this.Btn_OK_Click);
			// 
			// valueTextBox
			// 
			this.valueTextBox.BackColor = System.Drawing.Color.Black;
			this.valueTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.valueTextBox.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.valueTextBox.ForeColor = System.Drawing.SystemColors.Control;
			this.valueTextBox.Location = new System.Drawing.Point(21, 48);
			this.valueTextBox.Name = "valueTextBox";
			this.valueTextBox.Size = new System.Drawing.Size(168, 30);
			this.valueTextBox.TabIndex = 9;
			this.valueTextBox.TextChanged += new System.EventHandler(this.InputBoxValue_TextChanged);
			// 
			// mainLabel
			// 
			this.mainLabel.AutoSize = true;
			this.mainLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mainLabel.ForeColor = System.Drawing.SystemColors.Control;
			this.mainLabel.Location = new System.Drawing.Point(17, 17);
			this.mainLabel.Margin = new System.Windows.Forms.Padding(8);
			this.mainLabel.Name = "mainLabel";
			this.mainLabel.Size = new System.Drawing.Size(85, 19);
			this.mainLabel.TabIndex = 8;
			this.mainLabel.Text = "Enter a Map ID";
			// 
			// GoMapChoiceForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(231, 177);
			this.Controls.Add(this.cancelBtn);
			this.Controls.Add(this.okBtn);
			this.Controls.Add(this.valueTextBox);
			this.Controls.Add(this.mainLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "GoMapChoiceForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "GoMapChoiceForm";
			this.TextChanged += new System.EventHandler(this.InputBoxValue_TextChanged);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button cancelBtn;
		private System.Windows.Forms.Button okBtn;
		private System.Windows.Forms.TextBox valueTextBox;
		private System.Windows.Forms.Label mainLabel;
	}
}