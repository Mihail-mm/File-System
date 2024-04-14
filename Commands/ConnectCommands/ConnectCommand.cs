using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemPaths;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.ConnectCommands;

public class ConnectCommand : ICommand
{
    private readonly IFileSystemPath _path;
    private readonly IFileSystem _fileSystem;

    public ConnectCommand(IFileSystemPath path, IFileSystem fileSystem)
    {
        _path = path;
        _fileSystem = fileSystem;
    }

    public ExecuteResults Execute(Context context)
    {
        context.FileSystem = _fileSystem;
        if (context.FileSystem.PathIsCorrect(_path))
        {
            context.FileSystemPath = _path;
            return new ExecuteResults.Success();
        }

        return new ExecuteResults.Failed();
    }
}