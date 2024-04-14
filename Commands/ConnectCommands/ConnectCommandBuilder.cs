using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemPaths;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.ConnectCommands;

public class ConnectCommandBuilder
{
    private IFileSystemPath? _path;
    private IFileSystem? _fileSystem;

    public void WithFileSystem(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public void WithPath(IFileSystemPath path)
    {
        _path = path;
    }

    public ConnectCommand Build()
    {
        return new ConnectCommand(
            _path ?? throw new ArgumentNullException(nameof(_path)),
            _fileSystem ??= new LocalFileSystem());
    }
}