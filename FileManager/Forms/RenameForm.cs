using System;
using System.Windows.Forms;

namespace FileManager.Forms
{
	public partial class RenameForm : Form
	{
		public string NewName { get; private set; }

		public RenameForm(string currentName)
		{
			InitializeComponent();
			textBoxNewName.Text = currentName;
		}

		private void ButtonOk_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(textBoxNewName.Text))
			{
				MessageBox.Show(
					"Наименование не может быть пустым.",
					"Ошибка",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return;
			}

			NewName = textBoxNewName.Text;
			DialogResult = DialogResult.OK;
			Close();
		}

		private void ButtonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}