using FileManager.Abstractions;

namespace FileManager.Models
{
	public class DirectoryItem : IFileSystemItem
	{
		public string Name { get; }
		public bool IsDirectory => true;

		public DirectoryItem(string name)
		{
			Name = name;
		}
	}
}