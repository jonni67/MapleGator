namespace MapleGatorBot
{
	partial class Planner
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
			this.label1 = new System.Windows.Forms.Label();
			this.routineTree = new System.Windows.Forms.TreeView();
			this.label2 = new System.Windows.Forms.Label();
			this.triggerTree = new System.Windows.Forms.TreeView();
			this.label3 = new System.Windows.Forms.Label();
			this.categoryLabel = new System.Windows.Forms.Label();
			this.planTriggerBtn = new System.Windows.Forms.Button();
			this.planNewRoutineBtn = new System.Windows.Forms.Button();
			this.planActionBtn = new System.Windows.Forms.Button();
			this.elementsTree = new System.Windows.Forms.TreeView();
			this.trashTree = new System.Windows.Forms.TreeView();
			this.trashMob = new System.Windows.Forms.PictureBox();
			this.label5 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.trashMob)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.Control;
			this.label1.Location = new System.Drawing.Point(12, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(554, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "PLANNER - Plan your routine and triggers. Drag and drop elements into each catego" +
    "ry.";
			// 
			// routineTree
			// 
			this.routineTree.BackColor = System.Drawing.Color.Black;
			this.routineTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.routineTree.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.routineTree.ForeColor = System.Drawing.SystemColors.Control;
			this.routineTree.Location = new System.Drawing.Point(12, 136);
			this.routineTree.Margin = new System.Windows.Forms.Padding(8);
			this.routineTree.Name = "routineTree";
			this.routineTree.Size = new System.Drawing.Size(256, 297);
			this.routineTree.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.SystemColors.Control;
			this.label2.Location = new System.Drawing.Point(9, 97);
			this.label2.Margin = new System.Windows.Forms.Padding(8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "ROUTINE";
			// 
			// triggerTree
			// 
			this.triggerTree.BackColor = System.Drawing.Color.Black;
			this.triggerTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.triggerTree.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.triggerTree.ForeColor = System.Drawing.SystemColors.Control;
			this.triggerTree.Location = new System.Drawing.Point(284, 136);
			this.triggerTree.Margin = new System.Windows.Forms.Padding(8);
			this.triggerTree.Name = "triggerTree";
			this.triggerTree.Size = new System.Drawing.Size(256, 297);
			this.triggerTree.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.SystemColors.Control;
			this.label3.Location = new System.Drawing.Point(280, 97);
			this.label3.Margin = new System.Windows.Forms.Padding(8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(70, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "TRIGGERS";
			// 
			// categoryLabel
			// 
			this.categoryLabel.AutoSize = true;
			this.categoryLabel.BackColor = System.Drawing.Color.Transparent;
			this.categoryLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.categoryLabel.ForeColor = System.Drawing.SystemColors.Control;
			this.categoryLabel.Location = new System.Drawing.Point(548, 97);
			this.categoryLabel.Margin = new System.Windows.Forms.Padding(8);
			this.categoryLabel.Name = "categoryLabel";
			this.categoryLabel.Size = new System.Drawing.Size(137, 23);
			this.categoryLabel.TabIndex = 8;
			this.categoryLabel.Text = "CHOOSE A CATEGORY";
			// 
			// planTriggerBtn
			// 
			this.planTriggerBtn.BackColor = System.Drawing.Color.Transparent;
			this.planTriggerBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.planTriggerBtn.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.planTriggerBtn.ForeColor = System.Drawing.SystemColors.Control;
			this.planTriggerBtn.Location = new System.Drawing.Point(129, 51);
			this.planTriggerBtn.Margin = new System.Windows.Forms.Padding(8);
			this.planTriggerBtn.Name = "planTriggerBtn";
			this.planTriggerBtn.Size = new System.Drawing.Size(73, 30);
			this.planTriggerBtn.TabIndex = 9;
			this.planTriggerBtn.Text = "Triggers";
			this.planTriggerBtn.UseVisualStyleBackColor = false;
			this.planTriggerBtn.Click += new System.EventHandler(this.Btn_AddTrigger_Click);
			// 
			// planNewRoutineBtn
			// 
			this.planNewRoutineBtn.BackColor = System.Drawing.Color.Transparent;
			this.planNewRoutineBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.planNewRoutineBtn.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.planNewRoutineBtn.ForeColor = System.Drawing.SystemColors.Control;
			this.planNewRoutineBtn.Location = new System.Drawing.Point(13, 51);
			this.planNewRoutineBtn.Margin = new System.Windows.Forms.Padding(8);
			this.planNewRoutineBtn.Name = "planNewRoutineBtn";
			this.planNewRoutineBtn.Size = new System.Drawing.Size(100, 30);
			this.planNewRoutineBtn.TabIndex = 10;
			this.planNewRoutineBtn.Text = "New Routine";
			this.planNewRoutineBtn.UseVisualStyleBackColor = false;
			this.planNewRoutineBtn.Click += new System.EventHandler(this.Btn_NewRoutine_Click);
			// 
			// planActionBtn
			// 
			this.planActionBtn.BackColor = System.Drawing.Color.Transparent;
			this.planActionBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.planActionBtn.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.planActionBtn.ForeColor = System.Drawing.SystemColors.Control;
			this.planActionBtn.Location = new System.Drawing.Point(218, 51);
			this.planActionBtn.Margin = new System.Windows.Forms.Padding(8);
			this.planActionBtn.Name = "planActionBtn";
			this.planActionBtn.Size = new System.Drawing.Size(78, 30);
			this.planActionBtn.TabIndex = 11;
			this.planActionBtn.Text = "Actions";
			this.planActionBtn.UseVisualStyleBackColor = false;
			this.planActionBtn.Click += new System.EventHandler(this.Btn_AddAction_Click);
			// 
			// elementsTree
			// 
			this.elementsTree.BackColor = System.Drawing.Color.Black;
			this.elementsTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.elementsTree.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.elementsTree.ForeColor = System.Drawing.SystemColors.Control;
			this.elementsTree.Location = new System.Drawing.Point(552, 136);
			this.elementsTree.Margin = new System.Windows.Forms.Padding(8);
			this.elementsTree.Name = "elementsTree";
			this.elementsTree.Size = new System.Drawing.Size(184, 297);
			this.elementsTree.TabIndex = 12;
			// 
			// trashTree
			// 
			this.trashTree.BackColor = System.Drawing.Color.Black;
			this.trashTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.trashTree.Location = new System.Drawing.Point(669, 12);
			this.trashTree.Name = "trashTree";
			this.trashTree.Size = new System.Drawing.Size(67, 69);
			this.trashTree.TabIndex = 16;
			// 
			// trashMob
			// 
			this.trashMob.Enabled = false;
			this.trashMob.Image = global::MapleGatorBot.Properties.Resources.trash_mob;
			this.trashMob.Location = new System.Drawing.Point(669, 12);
			this.trashMob.Name = "trashMob";
			this.trashMob.Size = new System.Drawing.Size(67, 69);
			this.trashMob.TabIndex = 15;
			this.trashMob.TabStop = false;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.SystemColors.Control;
			this.label5.Location = new System.Drawing.Point(614, 9);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(49, 23);
			this.label5.TabIndex = 17;
			this.label5.Text = "TRASH";
			// 
			// Planner
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.CausesValidation = false;
			this.ClientSize = new System.Drawing.Size(748, 445);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.trashTree);
			this.Controls.Add(this.trashMob);
			this.Controls.Add(this.elementsTree);
			this.Controls.Add(this.planActionBtn);
			this.Controls.Add(this.planNewRoutineBtn);
			this.Controls.Add(this.planTriggerBtn);
			this.Controls.Add(this.categoryLabel);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.triggerTree);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.routineTree);
			this.Controls.Add(this.label1);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Planner";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Pathfinding";
			((System.ComponentModel.ISupportInitialize)(this.trashMob)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TreeView routineTree;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TreeView triggerTree;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label categoryLabel;
		private System.Windows.Forms.Button planTriggerBtn;
		private System.Windows.Forms.Button planNewRoutineBtn;
		private System.Windows.Forms.Button planActionBtn;
		private System.Windows.Forms.TreeView elementsTree;
		private System.Windows.Forms.PictureBox trashMob;
		private System.Windows.Forms.TreeView trashTree;
		private System.Windows.Forms.Label label5;
	}
}