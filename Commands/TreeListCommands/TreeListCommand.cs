using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemComponents;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Visitors;
using Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands;

public class TreeListCommand : ICommand
{
    private readonly int _depth;
    public TreeListCommand(int depth)
    {
        _depth = depth;
    }

    public ExecuteResults Execute(Context context)
    {
        if (context is { FileSystemPath: not null, FileSystem: not null })
        {
            IFileSystemComponent root = context.FileSystem.CreateFileSystemTree(context.FileSystemPath, 0, _depth);
            var visitor = new ConsoleShowVisitor(_depth);
            root.Accept(visitor);
            return new ExecuteResults.Success();
        }

        return new ExecuteResults.Failed();
    }
}