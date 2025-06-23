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
		#region Public Fields

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

		public System.Windows.Forms.Label HookedLabel
		{
			get { return hookedLabel; }
			set { hookedLabel = value; }
		}

		public System.Windows.Forms.Button HookedButton
		{
			get { return buttonHook; }
		}

		#endregion

		#region Private Members

		MapleGator _parent;

		#endregion

		public Primary(MapleGator parent)
		{
			InitializeComponent();
			_parent = parent;

			LoadProcessList();
			SetDesign();
		}

		#region Public Methods

		/// <summary>
		/// Loads processes into the UI combo box.
		/// </summary>
		public void LoadProcessList()
		{
			processComboBox.Items.Clear();
			processComboBox.Text = "";
			foreach (var proc in Process.GetProcessesByName("MapleLegends"))
			{
				processComboBox.Items.Add($"{proc.ProcessName} (PID: {proc.Id})");
			}

			if (processComboBox.Items.Count > 0)
				processComboBox.SelectedIndex = 0;
		}

		#endregion

		#region Private Methods

		private void SetDesign()
		{
			SettingsUpdateRate.Text = _parent.StateDelayMs.ToString();

			processPanel.BackColor = Styling.ALPHA_PANEL_COLOR;
			autoLoginPanel.BackColor = Styling.ALPHA_PANEL_COLOR;
			topPanel.BackColor = Styling.ALPHA_PANEL_COLOR;
			statPanel.BackColor = Styling.ALPHA_PANEL_COLOR;
			statusPanel.BackColor = Styling.ALPHA_PANEL_COLOR;
			settingsPanel.BackColor = Styling.ALPHA_PANEL_COLOR;

			hookedLabel.ForeColor = Styling.COLOR_OFF;
		}

		#endregion

		#region Form Callbacks

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

		private void SettingsUpdateRate_TextChanged(object sender, EventArgs e)
		{
			string v = SettingsUpdateRate.Text;
			int rate = 0;
			bool isValid = int.TryParse(v, out rate);
			Console.WriteLine(isValid);
			if(!isValid || rate <= 0 || rate > 1000000)
			{
				SettingsUpdateRate.Text = _parent.StateDelayMs.ToString();
				return;
			}

			_parent.SetUpdateRate(rate);
		}
	}
}
