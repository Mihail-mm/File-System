using System;
using Itmo.ObjectOrientedProgramming.Lab4.Drawers;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemPaths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileShowCommands;

public class FileShowBuilder
{
    private IFileSystemPath? _path;
    private IDrawer? _drawer;

    public void WithPath(IFileSystemPath path)
    {
        _path = path;
    }

    public void WithDrawer(IDrawer drawer)
    {
        _drawer = drawer;
    }

    public ICommand Build()
    {
        return new FileShowCommand(
            _path ?? throw new ArgumentNullException(nameof(_path)),
            _drawer ??= new ConsoleDrawer());
    }
}