using System.ComponentModel;

namespace FileManager.Forms
{
	partial class RenameForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private IContainer components = null;
		private System.Windows.Forms.TextBox textBoxNewName;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Button buttonCancel;

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
			this.Text = "Переименовать";

			this.textBoxNewName = new System.Windows.Forms.TextBox();
			this.buttonOk = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();

			// textBoxNewName
			this.textBoxNewName.Location = new System.Drawing.Point(12, 12);
			this.textBoxNewName.Name = "textBoxNewName";
			this.textBoxNewName.Size = new System.Drawing.Size(260, 23);

			// buttonOk
			this.buttonOk.Location = new System.Drawing.Point(116, 50);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 23);
			this.buttonOk.Text = "OK";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new System.EventHandler(this.ButtonOk_Click);

			// buttonCancel
			this.buttonCancel.Location = new System.Drawing.Point(197, 50);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.Text = "Отмена";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);

			// RenameForm
			this.ClientSize = new System.Drawing.Size(284, 91);
			this.Controls.Add(this.textBoxNewName);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.buttonCancel);
			this.Name = "RenameForm";
			this.Text = "Переименовать";
		}

		#endregion
	}
}