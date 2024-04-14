namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemPaths;

public class FileSystemPath : IFileSystemPath
{
    public FileSystemPath()
    {
        Path = string.Empty;
    }

    public FileSystemPath(string path)
    {
        Path = path;
    }

    public string Path { get; }

    public override string ToString()
    {
        return Path;
    }
}