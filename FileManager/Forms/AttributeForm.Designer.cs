using System.ComponentModel;

namespace FileManager.Forms
{
	partial class AttributeForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private IContainer components = null;
		private System.Windows.Forms.CheckBox checkBoxReadOnly;
		private System.Windows.Forms.CheckBox checkBoxHidden;
		private System.Windows.Forms.CheckBox checkBoxSystem;
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
			this.Text = "AttributeForm";

			this.checkBoxReadOnly = new System.Windows.Forms.CheckBox();
            this.checkBoxHidden = new System.Windows.Forms.CheckBox();
            this.checkBoxSystem = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            //
            // checkBoxReadOnly
            //
            this.checkBoxReadOnly.AutoSize = true;
            this.checkBoxReadOnly.Location = new System.Drawing.Point(20, 20);
            this.checkBoxReadOnly.Name = "checkBoxReadOnly";
            this.checkBoxReadOnly.Size = new System.Drawing.Size(108, 21);
            this.checkBoxReadOnly.Text = "Только чтение";
            this.checkBoxReadOnly.UseVisualStyleBackColor = true;

            //
            // checkBoxHidden
            //
            this.checkBoxHidden.AutoSize = true;
            this.checkBoxHidden.Location = new System.Drawing.Point(20, 50);
            this.checkBoxHidden.Name = "checkBoxHidden";
            this.checkBoxHidden.Size = new System.Drawing.Size(92, 21);
            this.checkBoxHidden.Text = "Скрытый";
            this.checkBoxHidden.UseVisualStyleBackColor = true;

            //
            // checkBoxSystem
            //
            this.checkBoxSystem.AutoSize = true;
            this.checkBoxSystem.Location = new System.Drawing.Point(20, 80);
            this.checkBoxSystem.Name = "checkBoxSystem";
            this.checkBoxSystem.Size = new System.Drawing.Size(97, 21);
            this.checkBoxSystem.Text = "Системный";
            this.checkBoxSystem.UseVisualStyleBackColor = true;

            //
            // btnSave
            //
            this.btnSave.Location = new System.Drawing.Point(20, 120);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 30);
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            //
            // btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(120, 120);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            //
            // AttributeForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 180);
            this.Controls.Add(this.checkBoxReadOnly);
            this.Controls.Add(this.checkBoxHidden);
            this.Controls.Add(this.checkBoxSystem);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Name = "AttributeForm";
            this.Text = "Изменение атрибутов";
		}

		#endregion
	}
}