using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemPaths;
using Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileDeleteCommands;

public class FileDeleteCommand : ICommand
{
    private readonly IFileSystemPath _path;
    public FileDeleteCommand(IFileSystemPath path)
    {
        _path = path;
    }

    public ExecuteResults Execute(Context context)
    {
        if (context.FileSystem is not null && context.FileSystem.PathIsCorrect(_path))
        {
            context.FileSystem.DeleteFile(_path);
            return new ExecuteResults.Success();
        }

        return new ExecuteResults.Failed();
    }
}