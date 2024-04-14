using Itmo.ObjectOrientedProgramming.Lab4.Drawers;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemPaths;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemComponents;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

public interface IFileSystem
{
    bool PathIsCorrect(IFileSystemPath path);
    void MoveFile(IFileSystemPath sourcePath, IFileSystemPath destinationPath);
    void CopyFile(IFileSystemPath sourcePath, IFileSystemPath destinationPath);
    void ShowFile(IFileSystemPath path, IDrawer drawer);
    void DeleteFile(IFileSystemPath path);
    void RenameFile(IFileSystemPath path, string fileName);
    IFileSystemComponent CreateFileSystemTree(IFileSystemPath path, int currentDepth, int maxDepth);
}