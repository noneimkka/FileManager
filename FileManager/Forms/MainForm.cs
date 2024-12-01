using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FileManager.Services;

namespace FileManager.Forms
{
	public partial class MainForm : Form
	{
		private readonly FileManager _fileManager;
        private readonly Timer _dragTimer = new Timer();
        private bool _isDragInitialized;
        private bool _isContextOpen;

		public MainForm(string openDirectory = @"C:\")
		{
			InitializeComponent();
            InitializeContextMenu();
			var logger = new Logger("log.txt");
			_fileManager = new FileManager(logger);
			LoadDirectoriesAndFiles(openDirectory);

            // Настройка таймера для управления перетаскиванием
            _dragTimer.Interval = 200; // Задержка в миллисекундах
            _dragTimer.Tick += DragTimer_Tick;


            // Подписываемся на событие Mediator
            FormMediator.OnUpdate += OnMediatorUpdate;

            // Отписываемся от события при закрытии формы
            FormClosed += (s, e) => FormMediator.OnUpdate -= OnMediatorUpdate;
		}

        // Метод, который вызывается, когда Mediator вызывает обновление
        private void OnMediatorUpdate(string[] message)
        {
            var currentPath = textBoxPath.Text;

            if (message.Contains(currentPath))
                LoadDirectoriesAndFiles(currentPath);
        }

        private void DragTimer_Tick(object sender, EventArgs e)
        {
            _dragTimer.Stop();

            if (_isContextOpen)
            {
                _isDragInitialized = false;
                return;
            }

            _isDragInitialized = true;

            if (listBoxFiles.SelectedItem != null)
            {
                string selected = listBoxFiles.SelectedItem.ToString();
                string path = _fileManager.CombinePath(textBoxPath.Text, selected.StartsWith("[DIR]") ? selected.Substring(6) : selected);

                DoDragDrop(path, DragDropEffects.Move | DragDropEffects.Copy);
            }
        }

        private void LoadDirectoriesAndFiles(string path)
        {
            try
            {
                listBoxFiles.Items.Clear();
                textBoxPath.Text = path;

                foreach (var item in _fileManager.GetDirectoryContents(path))
                {
                    listBoxFiles.Items.Add(item.IsDirectory ? $"[DIR] {item.Name}" : item.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void listBoxFiles_DoubleClick(object sender, EventArgs e)
        {
            if (_isDragInitialized)
                return; // Игнорируем, если начато перетаскивание

            if (listBoxFiles.SelectedItem == null)
                return;

            string selected = listBoxFiles.SelectedItem.ToString();
            string selectedPath = _fileManager.CombinePath(textBoxPath.Text, selected.StartsWith("[DIR]")
                ? selected.Substring(6)
                : selected);

            if (selected.StartsWith("[DIR]"))
            {
                if (Directory.Exists(selectedPath))
                {
                    LoadDirectoriesAndFiles(selectedPath);
                }
            }
            else
            {
                if (File.Exists(selectedPath))
                {
                    try
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = selectedPath,
                            UseShellExecute = true // Открываем в программе по умолчанию
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            $"Не удалось открыть файл: {ex.Message}",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnCreateFolder_Click(object sender, EventArgs e)
        {
            using (CreateItemForm createForm = new CreateItemForm())
            {
                if (createForm.ShowDialog() == DialogResult.OK)
                {
                    string newName = createForm.ItemName;
                    string path = Path.Combine(textBoxPath.Text, newName);

                    if (createForm.IsFolder)
                    {
                        Directory.CreateDirectory(path);
                    }
                    else
                    {
                        File.Create(path).Dispose(); // Создаем файл и сразу закрываем поток
                    }

                    LoadDirectoriesAndFiles(textBoxPath.Text); // Обновляем список
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBoxFiles.SelectedItem == null) return;

            string selected = listBoxFiles.SelectedItem.ToString();
            string path = textBoxPath.Text;

            if (selected.StartsWith("[DIR]"))
                _fileManager.DeleteDirectory(_fileManager.CombinePath(path, selected.Substring(6)));
            else
                _fileManager.DeleteFile(_fileManager.CombinePath(path, selected));

            LoadDirectoriesAndFiles(path);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDirectoriesAndFiles(textBoxPath.Text);
        }

        private void Refresh()
        {
            LoadDirectoriesAndFiles(textBoxPath.Text);
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            string currentPath = textBoxPath.Text;
            string parentPath = Directory.GetParent(currentPath)?.FullName;

            if (parentPath != null)
            {
                LoadDirectoriesAndFiles(parentPath);
            }
            else
            {
                MessageBox.Show("Вы уже находитесь в корневой директории.");
            }
        }

        private void textBoxPath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Переход при нажатии Enter
            {
                string newPath = textBoxPath.Text;

                if (Directory.Exists(newPath))
                {
                    LoadDirectoriesAndFiles(newPath);
                }
                else
                {
                    MessageBox.Show("Указанный путь не существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TextBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            string query = textBoxSearch.Text;
            string currentPath = textBoxPath.Text;

            if (string.IsNullOrWhiteSpace(query))
            {
                LoadDirectoriesAndFiles(currentPath);
                return;
            }

            var results = _fileManager.Search(currentPath, query);
            listBoxFiles.Items.Clear();

            foreach (var result in results)
            {
                listBoxFiles.Items.Add(result.IsDirectory ? $"[DIR] {result.Name}" : result.Name);
            }
        }

        private void btnChangeAttributes_Click(object sender, EventArgs e)
        {
            if (listBoxFiles.SelectedItem == null) return;

            string selected = listBoxFiles.SelectedItem.ToString();
            string path = _fileManager.CombinePath(textBoxPath.Text, selected.StartsWith("[DIR]")
                ? selected.Substring(6)
                : selected);

            using (var attributeForm = new AttributeForm(path))
            {
                attributeForm.ShowDialog();
            }
        }

        private void btnPermissions_Click(object sender, EventArgs e)
        {
            if (listBoxFiles.SelectedItem == null) return;

            string selected = listBoxFiles.SelectedItem.ToString();
            string path = _fileManager.CombinePath(textBoxPath.Text, selected.StartsWith("[DIR]")
                ? selected.Substring(6)
                : selected);

            using (var permissionsForm = new PermissionsForm(path))
            {
                permissionsForm.ShowDialog();
            }
        }

        private void btnOpenSecondWindow_Click(object sender, EventArgs e)
        {
            var secondWindow = new MainForm();
            secondWindow.Show();
        }

        private void btnOpenInNewWindow_Click(object sender, EventArgs e)
        {
            if (listBoxFiles.SelectedItem == null)
                return;

            var selected = listBoxFiles.SelectedItem.ToString();

            if (selected.StartsWith("[DIR]"))
            {
                string folderName = selected.Substring(6);
                var targetPath = Path.Combine(textBoxPath.Text, folderName);
                var secondWindow = new MainForm(targetPath);
                secondWindow.Show();
            }
        }

        // Начало перетаскивания
        private void listBoxFiles_MouseDown(object sender, MouseEventArgs e)
        {
            if (listBoxFiles.SelectedItem == null)
                return;

            if (e.Button == MouseButtons.Right)
            {
                int index = listBoxFiles.IndexFromPoint(e.Location);

                if (index != ListBox.NoMatches)
                {
                    listBoxFiles.SelectedIndex = index; // Выбираем элемент под курсором
                    contextMenu.Show(listBoxFiles, e.Location); // Отображаем меню
                }
            }

            if (e.Button == MouseButtons.Left && listBoxFiles.SelectedItem != null)
            {
                _isDragInitialized = false;
                _dragTimer.Start();
            }
        }

        // Начало перетаскивания
        private void listBoxFiles_MouseUp(object sender, MouseEventArgs e)
        {
            _dragTimer.Stop();
            _isDragInitialized = false;
        }

        // Обработка события DragEnter
        private void listBoxFiles_DragEnter(object sender, DragEventArgs e)
        {
            Point point = listBoxFiles.PointToClient(new Point(e.X, e.Y));
            int index = listBoxFiles.IndexFromPoint(point);

            if (listBoxFiles.SelectedIndex == index && index != ListBox.NoMatches)
            {
                e.Effect = DragDropEffects.None;
            }
            else
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        // Обработка события DragDrop
        private void listBoxFiles_DragDrop(object sender, DragEventArgs e)
        {
            Point point = listBoxFiles.PointToClient(new Point(e.X, e.Y));
            int index = listBoxFiles.IndexFromPoint(point);

            if (listBoxFiles.SelectedIndex == index && index != ListBox.NoMatches)
            {
                _isDragInitialized = false;
                return;
            }

            string targetPath = textBoxPath.Text;

            if (index >= 0)
            {
                string selected = listBoxFiles.Items[index].ToString();
                if (selected.StartsWith("[DIR]"))
                {
                    string folderName = selected.Substring(6);
                    targetPath = Path.Combine(textBoxPath.Text, folderName);
                }
            }

            if (!Directory.Exists(targetPath))
            {
                MessageBox.Show("Целевая папка недействительна.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                var pathsForUpdate = new List<string>
                {
                    targetPath,
                };

                foreach (var file in files)
                {
                    string dest = Path.Combine(targetPath, Path.GetFileName(file));
                    if (File.Exists(file))
                    {
                        File.Move(file, dest);
                    }
                    else if (Directory.Exists(file))
                    {
                        Directory.Move(file, dest);
                    }

                    pathsForUpdate.Add(Directory.GetParent(file)?.FullName);
                }

                FormMediator.UpdateFrom(pathsForUpdate.ToArray());
            }
            else if (e.Data.GetDataPresent(typeof(string)))
            {
                string sourcePath = e.Data.GetData(typeof(string)).ToString();
                string destPath = Path.Combine(targetPath, Path.GetFileName(sourcePath));

                if (File.Exists(sourcePath))
                {
                    File.Move(sourcePath, destPath);
                }
                else if (Directory.Exists(sourcePath))
                {
                    Directory.Move(sourcePath, destPath);
                }

                FormMediator.UpdateFrom(targetPath, Directory.GetParent(sourcePath)?.FullName);
            }

            LoadDirectoriesAndFiles(textBoxPath.Text);
        }

        // Рекурсивное копирование директории
        private void DirectoryCopy(string sourceDir, string destDir, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDir);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException($"Исходная папка не найдена: {sourceDir}");
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            Directory.CreateDirectory(destDir);

            foreach (FileInfo file in dir.GetFiles())
            {
                string tempPath = Path.Combine(destDir, file.Name);
                file.CopyTo(tempPath, false);
            }

            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(destDir, subdir.Name);
                    DirectoryCopy(subdir.FullName, tempPath, true);
                }
            }
        }

        private void listBoxFiles_DragOver(object sender, DragEventArgs e)
        {
            Point point = listBoxFiles.PointToClient(new Point(e.X, e.Y));
            int index = listBoxFiles.IndexFromPoint(point);

            if (index != listBoxFiles.SelectedIndex || index == ListBox.NoMatches)
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void listBoxFiles_DragLeave(object sender, EventArgs e)
        {
            _dragTimer.Stop();
            _isDragInitialized = false;
        }

        private void OpenItem_Click(object sender, EventArgs e)
        {
            listBoxFiles_DoubleClick(sender, e);
        }

        private void CopyItem_Click(object sender, EventArgs e)
        {
            if (listBoxFiles.SelectedItem == null) return;

            string selected = listBoxFiles.SelectedItem.ToString();
            string selectedPath = _fileManager.CombinePath(textBoxPath.Text, selected.StartsWith("[DIR]")
                ? selected.Substring(6)
                : selected);

            Clipboard.SetText(selectedPath);
        }

        private void PasteItem_Click(object sender, EventArgs e)
        {
            if (!Clipboard.ContainsText()) return;

            string sourcePath = Clipboard.GetText();
            string destPath = Path.Combine(textBoxPath.Text, Path.GetFileName(sourcePath));

            if (File.Exists(sourcePath))
            {
                File.Copy(sourcePath, destPath);
            }
            else if (Directory.Exists(sourcePath))
            {
                DirectoryCopy(sourcePath, destPath, true);
            }

            LoadDirectoriesAndFiles(textBoxPath.Text);
        }

        private void ShowAttributesForm()
        {
            if (listBoxFiles.SelectedItem == null) return;

            string selected = listBoxFiles.SelectedItem.ToString();
            string path = _fileManager.CombinePath(textBoxPath.Text, selected);

            if (!File.Exists(path) && !Directory.Exists(path)) return;

            using (AttributeForm attributeForm = new AttributeForm(path))
            {
                attributeForm.ShowDialog();
            }
        }

        private void ShowPermissionsForm()
        {
            if (listBoxFiles.SelectedItem == null) return;

            string selected = listBoxFiles.SelectedItem.ToString();
            string path = _fileManager.CombinePath(textBoxPath.Text, selected);

            if (!File.Exists(path) && !Directory.Exists(path)) return;

            using (PermissionsForm permissionsForm = new PermissionsForm(path))
            {
                permissionsForm.ShowDialog();
            }
        }

        private void AttributesItem_Click(object sender, EventArgs e)
        {
            if (listBoxFiles.SelectedItem == null) return;

            // Логика открытия окна для изменения атрибутов
            ShowAttributesForm();
        }

        private void PermissionsItem_Click(object sender, EventArgs e)
        {
            if (listBoxFiles.SelectedItem == null) return;

            // Логика изменения прав доступа
            ShowPermissionsForm();
        }

        private void ContextMenuStrip_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            _isContextOpen = false;
        }

        private void ContextMenuStrip_Opened(object sender, EventArgs e)
        {
            _isContextOpen = true;
            _dragTimer.Stop();
            _isDragInitialized = false;
        }

        private void RenameItem_Click(object sender, EventArgs e)
        {
            if (listBoxFiles.SelectedItem == null) return;

            string selected = listBoxFiles.SelectedItem.ToString();
            string oldPath = Path.Combine(textBoxPath.Text, selected);

            using (RenameForm renameForm = new RenameForm(selected))
            {
                if (renameForm.ShowDialog() == DialogResult.OK)
                {
                    string newName = renameForm.NewName;
                    string newPath = Path.Combine(textBoxPath.Text, newName);

                    if (File.Exists(oldPath))
                        File.Move(oldPath, newPath);
                    else if (Directory.Exists(oldPath))
                        Directory.Move(oldPath, newPath);

                    LoadDirectoriesAndFiles(textBoxPath.Text);
                }
            }
        }

    }
}