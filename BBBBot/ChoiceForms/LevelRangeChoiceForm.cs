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
	public partial class LevelRangeChoiceForm : Form
	{
		public event Action<LevelRangeChoiceForm, int, int> OnSuccess;

		Planner _parent;

		int _firstValue;
		int _secondValue;
		bool _valid = false;
		bool _valid2 = false;

		public LevelRangeChoiceForm(Planner parent)
		{
			InitializeComponent();
			_parent = parent;
		}

		public void Initialize()
		{
			Show();
			_parent.SuspendAll();

			_valid = false;
			_valid2 = false;
		}

		private void InputBoxValue_TextChanged(object sender, EventArgs e)
		{
			string v = valueTextBox.Text;
			bool isNumber = int.TryParse(v, out _firstValue);

			if (!isNumber || _firstValue <= 0 || _firstValue > 199)
			{
				valueTextBox.Text = "2";
				return;
			}

			if(_firstValue >= _secondValue)
			{
				valueTextBox2.Text = $"{_firstValue + 1}";
			}

			valueTextBox.Text = $"{_firstValue}";
			_valid = true;
		}

		private void InputBoxValue2_TextChange(object sender, EventArgs e)
		{
			if (!_valid)
			{
				_firstValue = 1;
				valueTextBox2.Text = $"{_firstValue + 1}";
				return;
			}

			string v2 = valueTextBox2.Text;
			bool isNumber = int.TryParse(v2, out _secondValue);

			// second value must be higher than first value
			// second value must be greater than 1 and less than 201
			if (!isNumber || _secondValue <= _firstValue ||
			_secondValue < 2 || _secondValue > 200)
			{
				valueTextBox2.Text = $"{_firstValue + 1}";
				return;
			}

			valueTextBox2.Text = $"{_secondValue}";
			_valid2 = true;
		}

		private void Btn_Cancel_Click(object snder, EventArgs e)
		{
			_valid = false;
			_valid2 = false;
			Close();
		}

		private void Btn_OK_Click(object snder, EventArgs e)
		{
			if (!_valid || !_valid2)
				return;

			_parent.ResumeAll();

			if (OnSuccess != null)
			{
				OnSuccess(this, _firstValue, _secondValue);
			}

			Close();
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			if (!_valid || !_valid2)
			{
				_parent.CancelDraggedNode();
			}

			_parent.ResumeAll();

			base.OnFormClosing(e);
		}
	}
}
