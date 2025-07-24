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
			this.searchMapTextBox = new System.Windows.Forms.TextBox();
			this.mainLabel = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.mapIdLabel = new System.Windows.Forms.Label();
			this.resultsComboBox = new System.Windows.Forms.ComboBox();
			this.continentComboBox = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// cancelBtn
			// 
			this.cancelBtn.BackColor = System.Drawing.Color.Transparent;
			this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cancelBtn.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cancelBtn.ForeColor = System.Drawing.SystemColors.Control;
			this.cancelBtn.Location = new System.Drawing.Point(101, 123);
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
			this.okBtn.Location = new System.Drawing.Point(21, 123);
			this.okBtn.Margin = new System.Windows.Forms.Padding(8);
			this.okBtn.Name = "okBtn";
			this.okBtn.Size = new System.Drawing.Size(64, 64);
			this.okBtn.TabIndex = 10;
			this.okBtn.Text = "OK";
			this.okBtn.UseVisualStyleBackColor = false;
			this.okBtn.Click += new System.EventHandler(this.Btn_OK_Click);
			// 
			// searchMapTextBox
			// 
			this.searchMapTextBox.BackColor = System.Drawing.Color.Black;
			this.searchMapTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.searchMapTextBox.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.searchMapTextBox.ForeColor = System.Drawing.SystemColors.Control;
			this.searchMapTextBox.Location = new System.Drawing.Point(200, 47);
			this.searchMapTextBox.Name = "searchMapTextBox";
			this.searchMapTextBox.Size = new System.Drawing.Size(348, 30);
			this.searchMapTextBox.TabIndex = 9;
			this.searchMapTextBox.TextChanged += new System.EventHandler(this.SearchBoxValue_TextChanged);
			// 
			// mainLabel
			// 
			this.mainLabel.AutoSize = true;
			this.mainLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mainLabel.ForeColor = System.Drawing.SystemColors.Control;
			this.mainLabel.Location = new System.Drawing.Point(196, 17);
			this.mainLabel.Margin = new System.Windows.Forms.Padding(8);
			this.mainLabel.Name = "mainLabel";
			this.mainLabel.Size = new System.Drawing.Size(47, 19);
			this.mainLabel.TabIndex = 8;
			this.mainLabel.Text = "Search";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.Control;
			this.label1.Location = new System.Drawing.Point(196, 88);
			this.label1.Margin = new System.Windows.Forms.Padding(8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(49, 19);
			this.label1.TabIndex = 12;
			this.label1.Text = "Results";
			// 
			// mapIdLabel
			// 
			this.mapIdLabel.AutoSize = true;
			this.mapIdLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mapIdLabel.ForeColor = System.Drawing.SystemColors.Control;
			this.mapIdLabel.Location = new System.Drawing.Point(17, 88);
			this.mapIdLabel.Margin = new System.Windows.Forms.Padding(8);
			this.mapIdLabel.Name = "mapIdLabel";
			this.mapIdLabel.Size = new System.Drawing.Size(57, 19);
			this.mapIdLabel.TabIndex = 13;
			this.mapIdLabel.Text = "Map ID: 0";
			// 
			// resultsComboBox
			// 
			this.resultsComboBox.BackColor = System.Drawing.Color.Black;
			this.resultsComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.resultsComboBox.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.resultsComboBox.ForeColor = System.Drawing.SystemColors.Control;
			this.resultsComboBox.FormattingEnabled = true;
			this.resultsComboBox.Location = new System.Drawing.Point(200, 125);
			this.resultsComboBox.Name = "resultsComboBox";
			this.resultsComboBox.Size = new System.Drawing.Size(348, 31);
			this.resultsComboBox.TabIndex = 14;
			this.resultsComboBox.TextChanged += new System.EventHandler(this.InputBoxValue_TextChanged);
			// 
			// continentComboBox
			// 
			this.continentComboBox.BackColor = System.Drawing.Color.Black;
			this.continentComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.continentComboBox.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.continentComboBox.ForeColor = System.Drawing.SystemColors.Control;
			this.continentComboBox.FormattingEnabled = true;
			this.continentComboBox.Location = new System.Drawing.Point(12, 46);
			this.continentComboBox.Name = "continentComboBox";
			this.continentComboBox.Size = new System.Drawing.Size(182, 31);
			this.continentComboBox.TabIndex = 15;
			this.continentComboBox.TextChanged += new System.EventHandler(this.SearchBoxValue_TextChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.SystemColors.Control;
			this.label3.Location = new System.Drawing.Point(8, 17);
			this.label3.Margin = new System.Windows.Forms.Padding(8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(60, 19);
			this.label3.TabIndex = 16;
			this.label3.Text = "Continent";
			// 
			// GoMapChoiceForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(560, 203);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.continentComboBox);
			this.Controls.Add(this.resultsComboBox);
			this.Controls.Add(this.mapIdLabel);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cancelBtn);
			this.Controls.Add(this.okBtn);
			this.Controls.Add(this.searchMapTextBox);
			this.Controls.Add(this.mainLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "GoMapChoiceForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Select a Map";
			this.TextChanged += new System.EventHandler(this.InputBoxValue_TextChanged);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button cancelBtn;
		private System.Windows.Forms.Button okBtn;
		private System.Windows.Forms.TextBox searchMapTextBox;
		private System.Windows.Forms.Label mainLabel;
		private System.Windows.Forms.Label label1;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private System.Windows.Forms.Label mapIdLabel;
		private System.Windows.Forms.ComboBox resultsComboBox;
		private System.Windows.Forms.ComboBox continentComboBox;
		private System.Windows.Forms.Label label3;
	}
}