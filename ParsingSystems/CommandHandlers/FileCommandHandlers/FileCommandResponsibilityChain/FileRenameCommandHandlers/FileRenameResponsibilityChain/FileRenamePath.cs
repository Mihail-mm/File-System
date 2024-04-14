using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileRenameCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemPaths;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileCommandResponsibilityChain.FileRenameCommandHandlers.FileRenameResponsibilityChain;

public class FileRenamePath : FileRenameChainLinkBase
{
    public override ICommand Handle(Iterator iterator, FileRenameBuilder builder)
    {
        builder.WithPath(new FileSystemPath(iterator.Current));
        if (!iterator.MoveNext())
        {
            return new UnknownCommand();
        }

        return Next?.Handle(iterator, builder) ?? new UnknownCommand();
    }
}