using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Drawers;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemPaths;
using Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileShowCommands;

public class FileShowCommand : ICommand
{
    private IFileSystemPath _path;
    private IDrawer _drawer;
    public FileShowCommand(IFileSystemPath path, IDrawer drawer)
    {
        _path = path;
        _drawer = drawer;
    }

    public ExecuteResults Execute(Context context)
    {
        if (context.FileSystem is not null && context.FileSystem.PathIsCorrect(_path))
        {
            context.FileSystem.ShowFile(_path, _drawer);
            return new ExecuteResults.Success();
        }

        return new ExecuteResults.Failed();
    }
}