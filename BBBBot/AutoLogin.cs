using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MapleGatorBot
{
	public partial class AutoLogin : Form
	{
		MapleGator _parent;

		public AutoLogin(MapleGator parent)
		{
			InitializeComponent();
			_parent = parent;

			SetDesign();
		}

		#region Private Methods

		private void SetDesign()
		{
			autoLoginPanel.BackColor = Styling.ALPHA_PANEL_COLOR;
			accountsPanel.BackColor = Styling.ALPHA_PANEL_COLOR;
		}

		#endregion

		#region Form Callbacks

		private void Btn_AutoLoginToggle_Click(object sender, EventArgs e)
		{
			_parent.AutoLoginEnabled = !_parent.AutoLoginEnabled;
			Styling.ToggleLabel(_parent.AutoLoginEnabled, autoLoginToggleLabel);
			Styling.ToggleButton(_parent.AutoLoginEnabled, buttonAutoLoginToggle);
		}

		private void Btn_SaveAccount_Click(object sender, EventArgs e)
		{
			bool validSave = autoLogUsername.Text.Length > 0
				&& autoLogPw.Text.Length > 0
				&& autoLogPin.Text.Length > 0
				&& autoLogCh.Text.Length > 0
				&& autoLogChar.Text.Length > 0;

			if(!validSave)
			{
				MessageBox.Show("Not all Account fields are filled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				Filter = "XML Files (*.xml)|*.xml",
				Title = "Save an XML File",
				FileName = $"{autoLogUsername}-{autoLogChar}.xml"
			};

			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				using (XmlWriter writer = XmlWriter.Create(saveFileDialog.FileName))
				{
					writer.WriteStartDocument();
					writer.WriteStartElement("Root");

					writer.WriteElementString("Username", autoLogUsername.Text);
					writer.WriteElementString("PW", autoLogPw.Text);
					writer.WriteElementString("Pin", autoLogPin.Text);
					writer.WriteElementString("Channel", autoLogCh.Text);
					writer.WriteElementString("Character", autoLogChar.Text);

					writer.WriteEndElement(); // </Root>
					writer.WriteEndDocument();
				}

				MessageBox.Show("Account File saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void Btn_LoadAccount_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Filter = "XML Files (*.xml)|*.xml",
				Title = "Open an XML File"
			};

			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				XmlDocument doc = new XmlDocument();
				try
				{
					doc.Load(openFileDialog.FileName);

					// Example: read values from known elements
					XmlNode nameNode = doc.SelectSingleNode("/Root/Username");
					XmlNode pwNode = doc.SelectSingleNode("/Root/PW");
					XmlNode pinNode = doc.SelectSingleNode("/Root/Pin");
					XmlNode chNode = doc.SelectSingleNode("/Root/Channel");
					XmlNode charNode = doc.SelectSingleNode("/Root/Character");

					string name = nameNode?.InnerText ?? "(none)";
					string pw = pwNode?.InnerText ?? "(none)";
					string pin = pinNode?.InnerText ?? "(none)";
					string ch = chNode?.InnerText ?? "(none)";
					string character = charNode?.InnerText ?? "(none)";
					string msg = $"Username: {name}\nPW: {pw}\nPin: {pin}\nChannel: {ch}\nCharacter: {character}";

					MessageBox.Show($"{msg}", "Account Loaded", MessageBoxButtons.OK, MessageBoxIcon.Information);

					autoLogUsername.Text = name;
					autoLogPw.Text = pw;
					autoLogPin.Text = pin;
					autoLogCh.Text = ch;
					autoLogChar.Text = character;
				}
				catch (Exception ex)
				{
					MessageBox.Show("Failed to load XML: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		#endregion
	}
}
