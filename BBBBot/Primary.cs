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

		MapleGator _parent;

		public Primary(MapleGator parent)
		{
			InitializeComponent();
			_parent = parent;
			LoadProcessList();
		}

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

		#region Callbacks
		private void Btn_Hook_Click(object sender, EventArgs e)
		{
			if (processComboBox.SelectedItem == null)
			{
				MessageBox.Show("Please select a MapleLegends process.");
				return;
			}

			// Extract PID from dropdown item
			string selected = processComboBox.SelectedItem.ToString();
			_parent.HookProcess(selected);
		}

		#endregion
	}
}
