using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapleGatorBot
{
	public partial class PlannerChoiceBox : Form
	{
		public event Action<int> OnSuccessfulHundredValue;

		bool _hundredValueMode = false;
		int _hundredValue;
		Planner _parent;
		bool _valid = false;

		public PlannerChoiceBox(Planner parent)
		{
			InitializeComponent();
			_parent = parent;
		}

		public void ShowHundredValueMode(string txt)
		{
			Show();
			mainLabel.Text = txt;
			_hundredValueMode = true;
			_parent.SuspendAll();
			_valid = false;
		}

		private void InputBoxValue_TextChanged(object sender, EventArgs e)
		{
			string v = valueTextBox.Text;

			if(_hundredValueMode)
			{
				bool isValid = int.TryParse(v, out _hundredValue);

				if (!isValid || _hundredValue <= 0 || _hundredValue > 100)
				{
					valueTextBox.Text = "50";
					return;
				}

				valueTextBox.Text = $"{_hundredValue}";
				_valid = true;
			}
		}

		private void Btn_Cancel_Click(object snder, EventArgs e)
		{
			_valid = false;
			Close();
		}

		private void Btn_OK_Click(object snder, EventArgs e)
		{
			if (!_valid)
				return;

			_parent.ResumeAll();

			if(_hundredValueMode && OnSuccessfulHundredValue != null)
			{
				OnSuccessfulHundredValue(_hundredValue);
			}

			Close();
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			if(!_valid)
			{
				_parent.CancelDraggedNode();
			}

			_parent.ResumeAll();

			base.OnFormClosing(e);
		}
	}
}
