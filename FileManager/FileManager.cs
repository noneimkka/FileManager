using System.Collections.Generic;
using System.IO;
using FileManager.Abstractions;
using FileManager.Models;

namespace FileManager
{
	public class FileManager
	{
		private readonly ILogger _logger;

		public FileManager(ILogger logger)
		{
			_logger = logger;
		}

		public IEnumerable<IFileSystemItem> GetDirectoryContents(string path)
		{
			var items = new List<IFileSystemItem>();

			foreach (var dir in Directory.GetDirectories(path))
			{
				items.Add(new DirectoryItem(Path.GetFileName(dir)));
			}

			foreach (var file in Directory.GetFiles(path))
			{
				items.Add(new FileItem(Path.GetFileName(file)));
			}

			_logger.Log($"Содержимое каталога {path} загружено.");
			return items;
		}

		public void CreateDirectory(string path, string name)
		{
			string fullPath = Path.Combine(path, name);
			Directory.CreateDirectory(fullPath);
			_logger.Log($"Каталог создан: {fullPath}");
		}

		public void DeleteDirectory(string path)
		{
			Directory.Delete(path, true);
			_logger.Log($"Каталог удален: {path}");
		}

		public void DeleteFile(string path)
		{
			File.Delete(path);
			_logger.Log($"Файл удален: {path}");
		}

		public string CombinePath(string basePath, string relativePath) => Path.Combine(basePath, relativePath);

		public IEnumerable<IFileSystemItem> Search(string path, string query)
		{
			var items = new List<IFileSystemItem>();

			foreach (var dir in Directory.GetDirectories(path, $"*{query}*"))
			{
				items.Add(new DirectoryItem(Path.GetFileName(dir)));
			}

			foreach (var file in Directory.GetFiles(path, $"*{query}*"))
			{
				items.Add(new FileItem(Path.GetFileName(file)));
			}

			_logger.Log($"Поиск в {path}: {query}");
			return items;
		}

		public void SetAttributes(string path, FileAttributes attributes)
		{
			File.SetAttributes(path, attributes);
			_logger.Log($"Атрибуты изменены для {path}: {attributes}");
		}

		public FileAttributes GetAttributes(string path)
		{
			return File.GetAttributes(path);
		}
	}
}