using System;
using System.IO;
using System.Security.AccessControl;
using System.Windows.Forms;

namespace FileManager.Forms
{
	public partial class PermissionsForm : Form
	{
		private readonly string _path;

        public PermissionsForm(string path)
        {
            InitializeComponent();
            _path = path;
            textBoxPath.Text = _path;
            LoadPermissions();
        }

        private void LoadPermissions()
        {
            var security = File.GetAccessControl(_path);
            var rules = security.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount));

            foreach (FileSystemAccessRule rule in rules)
            {
                if (rule.AccessControlType == AccessControlType.Allow)
                {
                    if ((rule.FileSystemRights & FileSystemRights.Read) != 0) checkBoxRead.Checked = true;
                    if ((rule.FileSystemRights & FileSystemRights.Write) != 0) checkBoxWrite.Checked = true;
                    if ((rule.FileSystemRights & FileSystemRights.ExecuteFile) != 0) checkBoxExecute.Checked = true;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var security = File.GetAccessControl(_path);
                var rules = new FileSystemAccessRule(
                    Environment.UserName,
                    (checkBoxRead.Checked ? FileSystemRights.Read : 0) |
                    (checkBoxWrite.Checked ? FileSystemRights.Write : 0) |
                    (checkBoxExecute.Checked ? FileSystemRights.ExecuteFile : 0),
                    AccessControlType.Allow);

                security.AddAccessRule(rules);
                File.SetAccessControl(_path, security);

                MessageBox.Show("Права доступа обновлены.", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при изменении прав доступа: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
	}
}