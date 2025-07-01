using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapleGatorBot.ChoiceForms
{
	public partial class GoMapChoiceForm : Form
	{
		public event Action<GoMapChoiceForm, int> OnSuccess;

		Planner _parent;

		int _firstValue;
		bool _valid = false;

		public GoMapChoiceForm()
		{
			InitializeComponent();
		}

		public GoMapChoiceForm(Planner parent)
		{
			InitializeComponent();
			_parent = parent;
		}

		public void Initialize()
		{
			Show();
			_parent.SuspendAll();

			_valid = false;
		}

		private void InputBoxValue_TextChanged(object sender, EventArgs e)
		{
			string v = valueTextBox.Text;
			bool isNumber = int.TryParse(v, out _firstValue);

			if (!isNumber || _firstValue <= 0)
			{
				valueTextBox.Text = "40000";
				return;
			}

			valueTextBox.Text = $"{_firstValue}";
			_valid = true;
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

			if (OnSuccess != null)
			{
				OnSuccess(this, _firstValue);
			}

			Close();
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			if (!_valid)
			{
				_parent.CancelDraggedNode();
			}

			_parent.ResumeAll();

			if (OnSuccess != null)
			{
				OnSuccess(this, _firstValue);
			}

			base.OnFormClosing(e);
		}
	}
}
