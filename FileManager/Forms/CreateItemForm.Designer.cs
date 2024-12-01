using System.ComponentModel;

namespace FileManager.Forms
{
	partial class CreateItemForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private IContainer components = null;
		private System.Windows.Forms.TextBox textBoxItemName;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.RadioButton radioButtonFile;
		private System.Windows.Forms.RadioButton radioButtonFolder;

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
			this.textBoxItemName = new System.Windows.Forms.TextBox();
	        this.buttonOk = new System.Windows.Forms.Button();
	        this.buttonCancel = new System.Windows.Forms.Button();
	        this.radioButtonFile = new System.Windows.Forms.RadioButton();
	        this.radioButtonFolder = new System.Windows.Forms.RadioButton();

	        // textBoxItemName
	        this.textBoxItemName.Location = new System.Drawing.Point(12, 12);
	        this.textBoxItemName.Name = "textBoxItemName";
	        this.textBoxItemName.Size = new System.Drawing.Size(260, 23);

	        // radioButtonFile
	        this.radioButtonFile.AutoSize = true;
	        this.radioButtonFile.Location = new System.Drawing.Point(12, 50);
	        this.radioButtonFile.Name = "radioButtonFile";
	        this.radioButtonFile.Size = new System.Drawing.Size(49, 19);
	        this.radioButtonFile.Text = "Файл";
	        this.radioButtonFile.UseVisualStyleBackColor = true;

	        // radioButtonFolder
	        this.radioButtonFolder.AutoSize = true;
	        this.radioButtonFolder.Checked = true;
	        this.radioButtonFolder.Location = new System.Drawing.Point(12, 75);
	        this.radioButtonFolder.Name = "radioButtonFolder";
	        this.radioButtonFolder.Size = new System.Drawing.Size(61, 19);
	        this.radioButtonFolder.Text = "Папка";
	        this.radioButtonFolder.UseVisualStyleBackColor = true;

	        // buttonOk
	        this.buttonOk.Location = new System.Drawing.Point(116, 110);
	        this.buttonOk.Name = "buttonOk";
	        this.buttonOk.Size = new System.Drawing.Size(75, 23);
	        this.buttonOk.Text = "OK";
	        this.buttonOk.UseVisualStyleBackColor = true;
	        this.buttonOk.Click += new System.EventHandler(this.ButtonOk_Click);

	        // buttonCancel
	        this.buttonCancel.Location = new System.Drawing.Point(197, 110);
	        this.buttonCancel.Name = "buttonCancel";
	        this.buttonCancel.Size = new System.Drawing.Size(75, 23);
	        this.buttonCancel.Text = "Отмена";
	        this.buttonCancel.UseVisualStyleBackColor = true;
	        this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);

	        // CreateItemForm
	        this.ClientSize = new System.Drawing.Size(284, 151);
	        this.Controls.Add(this.textBoxItemName);
	        this.Controls.Add(this.radioButtonFile);
	        this.Controls.Add(this.radioButtonFolder);
	        this.Controls.Add(this.buttonOk);
	        this.Controls.Add(this.buttonCancel);
	        this.Name = "CreateItemForm";
	        this.Text = "Создать";
		}

		#endregion
	}
}