using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemPaths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeGotoCommands;

public class TreeGotoBuilder
{
    private IFileSystemPath? _path;

    public void WithPath(IFileSystemPath path)
    {
        _path = path;
    }

    public ICommand Build()
    {
        return new TreeGotoCommand(_path ?? throw new ArgumentNullException(nameof(_path)));
    }
}