using Itmo.ObjectOrientedProgramming.Lab4.FileSystemPaths;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Contexts;

public class Context
{
    public IFileSystem? FileSystem { get; set; }
    public IFileSystemPath? FileSystemPath { get; set; }
}