using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemPaths;
using Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeGotoCommands;

public class TreeGotoCommand : ICommand
{
    private IFileSystemPath _path;

    public TreeGotoCommand(IFileSystemPath path)
    {
        _path = path;
    }

    public ExecuteResults Execute(Context context)
    {
        if (context.FileSystem != null && context.FileSystem.PathIsCorrect(_path))
        {
            context.FileSystemPath = _path;
            return new ExecuteResults.Success();
        }

        return new ExecuteResults.Failed();
    }
}