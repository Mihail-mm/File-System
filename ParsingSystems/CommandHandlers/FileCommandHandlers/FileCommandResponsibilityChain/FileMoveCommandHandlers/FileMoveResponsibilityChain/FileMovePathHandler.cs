using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileMoveCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemPaths;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileCommandResponsibilityChain.FileMoveCommandHandlers.FileMoveResponsibilityChain;

public class FileMovePathHandler : FileMoveChainLinkBase
{
    public override ICommand Handle(Iterator iterator, FileMoveBuilder builder)
    {
        builder.WithSourcePath(new FileSystemPath(iterator.Current));
        if (!iterator.MoveNext())
        {
            return new UnknownCommand();
        }

        builder.WithDestinationPath(new FileSystemPath(iterator.Current));
        return Next?.Handle(iterator, builder) ?? new UnknownCommand();
    }
}