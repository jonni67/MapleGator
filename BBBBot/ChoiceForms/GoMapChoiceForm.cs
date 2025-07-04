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

			List<string> continents = _parent.GatorParent.Continents;
			for(int i = 0; i < continents.Count; i++)
			{
				continentComboBox.Items.Add(continents[i]);
			}
		}

		public void Initialize()
		{
			Show();
			_parent.SuspendAll();

			_valid = false;
		}

		private void SearchBoxValue_TextChanged(object sender, EventArgs e)
		{
			string term = searchMapTextBox.Text;
			string cont = continentComboBox.Text;
			Console.WriteLine($"Searching for maps in {cont} with term: {term}");

			resultsComboBox.Items.Clear();
			List<string> searchResults = _parent.GatorParent.SearchSimilarMapsByTerm(cont, term);

			for (int i = 0; i < searchResults.Count; i++)
			{
				resultsComboBox.Items.Add(searchResults[i]);
			}

			if(searchResults.Count > 0)
			{
				resultsComboBox.Text = searchResults[0];
			}
		}

		private void InputBoxValue_TextChanged(object sender, EventArgs e)
		{
			string v = resultsComboBox.Text;
			int id = 0;
			bool success = _parent.GatorParent.TryGetMapID(continentComboBox.Text, v, out id);
			if (!success)
				return;

			mapIdLabel.Text = $"Map ID: {id}";
			_firstValue = id;
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
