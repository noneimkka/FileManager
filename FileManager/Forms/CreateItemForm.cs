using System;
using System.Windows.Forms;

namespace FileManager.Forms
{
	public partial class CreateItemForm : Form
	{
		public string ItemName { get; private set; }
		public bool IsFolder { get; private set; }

		public CreateItemForm()
		{
			InitializeComponent();
		}

		private void ButtonOk_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(textBoxItemName.Text))
			{
				MessageBox.Show("Наименование не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			ItemName = textBoxItemName.Text;
			IsFolder = radioButtonFolder.Checked;
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