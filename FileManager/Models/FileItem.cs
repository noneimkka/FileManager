using FileManager.Abstractions;

namespace FileManager.Models
{
	public class FileItem : IFileSystemItem
	{
		public string Name { get; }
		public bool IsDirectory => false;

		public FileItem(string name)
		{
			Name = name;
		}
	}
}