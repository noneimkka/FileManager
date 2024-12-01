namespace FileManager.Abstractions
{
	public interface IFileSystemItem
	{
		string Name { get; }
		bool IsDirectory { get; }
	}
}