using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemPaths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCopyCommands;

public class FileCopyBuilder
{
    private IFileSystemPath? _sourcePath;
    private IFileSystemPath? _destinationPath;

    public void WithSourcePath(IFileSystemPath sourcePath)
    {
        _sourcePath = sourcePath;
    }

    public void WithDestinationPath(IFileSystemPath destinationPath)
    {
        _destinationPath = destinationPath;
    }

    public ICommand Build()
    {
        return new FileCopyCommand(
            _sourcePath ?? throw new ArgumentNullException(nameof(_sourcePath)),
            _destinationPath ?? throw new ArgumentNullException(nameof(_destinationPath)));
    }
}