using System;
using System.IO;
using System.Windows.Forms;

namespace FileManager.Forms
{
	public partial class AttributeForm : Form
	{
		private readonly string _path;

		public AttributeForm(string path)
		{
			InitializeComponent();
			_path = path;
			LoadAttributes();
		}

		private void LoadAttributes()
		{
			var attributes = File.GetAttributes(_path);

			checkBoxReadOnly.Checked = attributes.HasFlag(FileAttributes.ReadOnly);
			checkBoxHidden.Checked = attributes.HasFlag(FileAttributes.Hidden);
			checkBoxSystem.Checked = attributes.HasFlag(FileAttributes.System);
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			var attributes = FileAttributes.Normal;

			if (checkBoxReadOnly.Checked) attributes |= FileAttributes.ReadOnly;
			if (checkBoxHidden.Checked) attributes |= FileAttributes.Hidden;
			if (checkBoxSystem.Checked) attributes |= FileAttributes.System;

			File.SetAttributes(_path, attributes);
			MessageBox.Show("Атрибуты успешно обновлены.");
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

	}
}