using System.ComponentModel;

namespace FileManager.Forms
{
	partial class PermissionsForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private IContainer components = null;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.CheckBox checkBoxRead;
        private System.Windows.Forms.CheckBox checkBoxWrite;
        private System.Windows.Forms.CheckBox checkBoxExecute;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}

			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Text = "PermissionsForm";

			this.labelPath = new System.Windows.Forms.Label();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.checkBoxRead = new System.Windows.Forms.CheckBox();
            this.checkBoxWrite = new System.Windows.Forms.CheckBox();
            this.checkBoxExecute = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            // labelPath
            this.labelPath.Text = "Путь:";
            this.labelPath.Location = new System.Drawing.Point(12, 12);

            // textBoxPath
            this.textBoxPath.Location = new System.Drawing.Point(12, 30);
            this.textBoxPath.ReadOnly = true;
            this.textBoxPath.Size = new System.Drawing.Size(360, 22);

            // checkBoxRead
            this.checkBoxRead.Location = new System.Drawing.Point(12, 70);
            this.checkBoxRead.Text = "Чтение";

            // checkBoxWrite
            this.checkBoxWrite.Location = new System.Drawing.Point(12, 100);
            this.checkBoxWrite.Text = "Запись";

            // checkBoxExecute
            this.checkBoxExecute.Location = new System.Drawing.Point(12, 130);
            this.checkBoxExecute.Text = "Исполнение";

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(12, 170);
            this.btnSave.Text = "Сохранить";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(100, 170);
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // PermissionsForm
            this.ClientSize = new System.Drawing.Size(400, 220);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.checkBoxRead);
            this.Controls.Add(this.checkBoxWrite);
            this.Controls.Add(this.checkBoxExecute);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Text = "Настройка прав доступа";
		}

		#endregion
	}
}