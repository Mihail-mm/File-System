using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemPaths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileRenameCommands;

public class FileRenameBuilder
{
    private IFileSystemPath? _path;
    private string? _nameFile;

    public void WithPath(IFileSystemPath path)
    {
        _path = path;
    }

    public void WithName(string name)
    {
        _nameFile = name;
    }

    public ICommand Build()
    {
        return new FileRenameCommand(
            _path ?? throw new ArgumentNullException(nameof(_path)),
            _nameFile ?? throw new ArgumentException(nameof(_nameFile)));
    }
}