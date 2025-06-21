using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MapleGatorBot
{
	public partial class Primary : Form
	{
		public System.Windows.Forms.ComboBox ProcessComboBox 
		{ 
			get { return processComboBox; }
		}

		public System.Windows.Forms.Label TimerLabel
		{
			get { return timerLabel; }
			set { timerLabel = value; }
		}

		public System.Windows.Forms.Label StatusLabel
		{
			get { return statusLabel; }
			set { statusLabel = value; }
		}

		MapleGator _parent;
		Color _panelColor;

		public Primary(MapleGator parent)
		{
			InitializeComponent();
			_parent = parent;

			LoadProcessList();
			SetDesignParams();
		}

		/// <summary>
		/// Loads processes into the UI combo box.
		/// </summary>
		private void LoadProcessList()
		{
			processComboBox.Items.Clear();
			foreach (var proc in Process.GetProcessesByName("MapleLegends"))
			{
				processComboBox.Items.Add($"{proc.ProcessName} (PID: {proc.Id})");
			}

			if (processComboBox.Items.Count > 0)
				processComboBox.SelectedIndex = 0;
		}
		
		private void SetDesignParams()
		{
			_panelColor = Color.FromArgb(Styling.PANEL_ALPHA, Styling.PANEL_COLOR);
			processPanel.BackColor = _panelColor;
			autoLoginPanel.BackColor = _panelColor;
			topPanel.BackColor = _panelColor;
			statPanel.BackColor = _panelColor;
			statusPanel.BackColor = _panelColor;
		}

		#region Callbacks

		private void Btn_Hook_Click(object sender, EventArgs e)
		{
			if (processComboBox.SelectedItem == null)
			{
				MessageBox.Show("Please select a MapleLegends process.");
				return;
			}

			string selected = processComboBox.SelectedItem.ToString();
			_parent.HookProcess(selected);
		}

		private void Btn_AutoLoginToggle_Click(object sender, EventArgs e)
		{
			_parent.AutoLoginEnabled = !_parent.AutoLoginEnabled;
			Styling.ToggleLabel(_parent.AutoLoginEnabled, autoLoginToggleLabel);
			Styling.ToggleButton(_parent.AutoLoginEnabled, buttonAutoLoginToggle);
		}

		#endregion
	}
}
