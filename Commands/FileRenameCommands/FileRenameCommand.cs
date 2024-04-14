using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemPaths;
using Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileRenameCommands;

public class FileRenameCommand : ICommand
{
    private IFileSystemPath _path;
    private string _name;
    public FileRenameCommand(IFileSystemPath path, string name)
    {
        _path = path;
        _name = name;
    }

    public ExecuteResults Execute(Context context)
    {
        if (context.FileSystem is not null && context.FileSystem.PathIsCorrect(_path))
        {
            context.FileSystem.RenameFile(_path, _name);
            return new ExecuteResults.Success();
        }

        return new ExecuteResults.Failed();
    }
}