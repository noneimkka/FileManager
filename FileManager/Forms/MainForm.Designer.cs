using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FileManager.Forms
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private IContainer components = null;
		private System.Windows.Forms.TextBox textBoxPath;
		private System.Windows.Forms.ListBox listBoxFiles;
		private System.Windows.Forms.Button btnCreateFolder;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.Button btnGoBack;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.TextBox textBoxSearch;
		private System.Windows.Forms.Button btnChangeAttributes;
		private System.Windows.Forms.Button btnPermissions;
		private System.Windows.Forms.Button btnOpenSecondWindow;
		private ContextMenuStrip contextMenu;

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

		private void InitializeContextMenu()
		{
			contextMenu = new ContextMenuStrip();

			var openItem = new ToolStripMenuItem("Открыть", null, OpenItem_Click);
			var openNewWindowItem = new ToolStripMenuItem("Открыть в новом окне", null, btnOpenInNewWindow_Click);
			var renameItem = new ToolStripMenuItem("Переименовать", null, RenameItem_Click);
			var copyItem = new ToolStripMenuItem("Копировать", null, CopyItem_Click);
			var pasteItem = new ToolStripMenuItem("Вставить", null, PasteItem_Click);
			var attributesItem = new ToolStripMenuItem("Атрибуты", null, AttributesItem_Click);
			var permissionsItem = new ToolStripMenuItem("Права", null, PermissionsItem_Click);

			contextMenu.Items.AddRange(new ToolStripItem[]
			{
				openItem,
				openNewWindowItem,
				renameItem,
				copyItem,
				pasteItem,
				attributesItem,
				permissionsItem
			});

			listBoxFiles.ContextMenuStrip = contextMenu;
			listBoxFiles.ContextMenuStrip.Closed += new ToolStripDropDownClosedEventHandler(this.ContextMenuStrip_Closed);
			listBoxFiles.ContextMenuStrip.Opened += new EventHandler(this.ContextMenuStrip_Opened);
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.textBoxPath = new System.Windows.Forms.TextBox();
			this.listBoxFiles = new System.Windows.Forms.ListBox();
			this.btnCreateFolder = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnRefresh = new System.Windows.Forms.Button();

			// textBoxPath
			this.textBoxPath.Location = new System.Drawing.Point(12, 12);
			this.textBoxPath.Size = new System.Drawing.Size(500, 22);
			this.textBoxPath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxPath_KeyDown);

			// listBoxFiles
			this.listBoxFiles.Location = new System.Drawing.Point(12, 50);
			this.listBoxFiles.Size = new System.Drawing.Size(500, 300);
			this.listBoxFiles.DoubleClick += new System.EventHandler(this.listBoxFiles_DoubleClick);
			this.listBoxFiles.AllowDrop = true;
			this.listBoxFiles.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBoxFiles_MouseDown);
			this.listBoxFiles.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listBoxFiles_MouseUp);
			this.listBoxFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBoxFiles_DragEnter);
			this.listBoxFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBoxFiles_DragDrop);
			this.listBoxFiles.DragOver += new System.Windows.Forms.DragEventHandler(this.listBoxFiles_DragOver);
			this.listBoxFiles.DragLeave += new EventHandler(this.listBoxFiles_DragLeave);

			// btnCreateFolder
			this.btnCreateFolder.Location = new System.Drawing.Point(520, 50);
			this.btnCreateFolder.Text = "Создать папку";
			this.btnCreateFolder.Click += new System.EventHandler(this.btnCreateFolder_Click);

			// btnDelete
			this.btnDelete.Location = new System.Drawing.Point(520, 90);
			this.btnDelete.Text = "Удалить";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

			// btnRefresh
			this.btnRefresh.Location = new System.Drawing.Point(520, 130);
			this.btnRefresh.Text = "Обновить";
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

			// Кнопка "Назад"
			this.btnGoBack = new System.Windows.Forms.Button();
			this.btnGoBack.Location = new System.Drawing.Point(520, 170);
			this.btnGoBack.Text = "Назад";
			this.btnGoBack.Click += new System.EventHandler(this.btnGoBack_Click);

			// Поле поиска
			this.textBoxSearch = new System.Windows.Forms.TextBox();
			this.textBoxSearch.Location = new System.Drawing.Point(12, 360);
			this.textBoxSearch.Size = new System.Drawing.Size(400, 22);
			this.textBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxSearch_KeyDown);

			// Кнопка "Поиск"
			this.btnSearch = new System.Windows.Forms.Button();
			this.btnSearch.Location = new System.Drawing.Point(420, 360);
			this.btnSearch.Text = "Поиск";
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

			// Кнопка "Изменить атрибуты"
			this.btnChangeAttributes = new System.Windows.Forms.Button();
			this.btnChangeAttributes.Location = new System.Drawing.Point(520, 210);
			this.btnChangeAttributes.Text = "Атрибуты";
			this.btnChangeAttributes.Click += new System.EventHandler(this.btnChangeAttributes_Click);

			// Инициализация кнопки "Права доступа"
			this.btnPermissions = new System.Windows.Forms.Button();
			this.btnPermissions.Location = new System.Drawing.Point(520, 250);
			this.btnPermissions.Text = "Права доступа";
			this.btnPermissions.Click += new System.EventHandler(this.btnPermissions_Click);

			this.btnOpenSecondWindow = new System.Windows.Forms.Button();
			this.btnOpenSecondWindow.Location = new System.Drawing.Point(520, 12);
			this.btnOpenSecondWindow.Size = new System.Drawing.Size(30, 22);
			this.btnOpenSecondWindow.Text = "+";
			this.btnOpenSecondWindow.Font = new Font(this.btnOpenSecondWindow.Font.FontFamily, 10, FontStyle.Bold);
			this.btnOpenSecondWindow.Click += new System.EventHandler(this.btnOpenSecondWindow_Click);

			// MainForm
			this.ClientSize = new System.Drawing.Size(600, 400);
			this.Controls.Add(this.textBoxPath);
			this.Controls.Add(this.listBoxFiles);
			this.Controls.Add(this.btnCreateFolder);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnRefresh);
			this.Controls.Add(this.btnGoBack);
			this.Controls.Add(this.textBoxSearch);
			this.Controls.Add(this.btnSearch);
			this.Controls.Add(this.btnChangeAttributes);
			this.Controls.Add(this.btnPermissions);
			this.Controls.Add(this.btnOpenSecondWindow);
			this.Text = "Файловый менеджер";
		}

		#endregion
	}
}