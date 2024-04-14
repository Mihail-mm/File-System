using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemPaths;
using Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileMoveCommands;

public class FileMoveCommand : ICommand
{
    private IFileSystemPath _sourcePath;
    private IFileSystemPath _destinationPath;

    public FileMoveCommand(IFileSystemPath sourcePath, IFileSystemPath destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public ExecuteResults Execute(Context context)
    {
        if (context.FileSystem is not null && context.FileSystem.PathIsCorrect(_sourcePath) && context.FileSystem.PathIsCorrect(_destinationPath))
        {
            context.FileSystem.MoveFile(_sourcePath, _destinationPath);
            return new ExecuteResults.Success();
        }

        return new ExecuteResults.Failed();
    }
}