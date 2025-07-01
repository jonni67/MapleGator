using System;
using System.Windows.Forms;

namespace MapleGatorBot
{
	public partial class HPBelowChoiceForm : Form
	{
		public event Action<HPBelowChoiceForm, int> OnSuccess;

		Planner _parent;

		int _firstValue;
		bool _valid = false;

		public HPBelowChoiceForm(Planner parent)
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

			if (!isNumber || _firstValue <= 0 || _firstValue > 100)
			{
				valueTextBox.Text = "50";
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

			if(OnSuccess != null)
			{
				OnSuccess(this, _firstValue);
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
