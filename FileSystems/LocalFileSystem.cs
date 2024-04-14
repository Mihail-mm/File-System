using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Drawers;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemPaths;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemComponents;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

public class LocalFileSystem : IFileSystem
{
    public bool PathIsCorrect(IFileSystemPath path)
    {
        return Directory.Exists(path.ToString());
    }

    public void MoveFile(IFileSystemPath sourcePath, IFileSystemPath destinationPath)
    {
        if (File.Exists(sourcePath.ToString()) && File.Exists(destinationPath.ToString()))
        {
            File.Move(sourcePath.ToString() ?? string.Empty, destinationPath.ToString() ?? string.Empty);
        }
    }

    public void CopyFile(IFileSystemPath sourcePath, IFileSystemPath destinationPath)
    {
        if (File.Exists(sourcePath.ToString()) && File.Exists(destinationPath.ToString()))
        {
            File.Copy(sourcePath.ToString() ?? string.Empty, destinationPath.ToString() ?? string.Empty);
        }
    }

    public void ShowFile(IFileSystemPath path, IDrawer drawer)
    {
        if (File.Exists(path.ToString()))
        {
            string text = File.ReadAllText(path.ToString() ?? string.Empty);
            drawer.Print(text);
        }
    }

    public void DeleteFile(IFileSystemPath path)
    {
        if (File.Exists(path.ToString()))
        {
            File.Delete(path.ToString() ?? string.Empty);
        }
    }

    public void RenameFile(IFileSystemPath path, string fileName)
    {
        if (File.Exists(path.ToString()))
        {
            string? directory = Path.GetDirectoryName(path.ToString());
            string newFilePath = Path.Combine(directory ?? string.Empty, fileName);

            File.Move(path.ToString() ?? string.Empty, newFilePath);
        }
    }

    public IFileSystemComponent CreateFileSystemTree(IFileSystemPath path, int currentDepth, int maxDepth)
    {
        var directory = new DirectoryComponent(Path.GetFileName(path.ToString() ?? string.Empty));
        string[] files = Directory.GetFiles(path.ToString() ?? string.Empty);
        foreach (string file in files)
        {
            directory.Add(new FileComponent(Path.GetFileName(file)));
        }

        string[] directories = Directory.GetDirectories(path.ToString() ?? string.Empty);
        foreach (string dir in directories)
        {
            if (currentDepth < maxDepth)
            {
                directory.Add(CreateFileSystemTree(new FileSystemPath(dir), currentDepth + 1, maxDepth));
            }
        }

        return directory;
    }
}