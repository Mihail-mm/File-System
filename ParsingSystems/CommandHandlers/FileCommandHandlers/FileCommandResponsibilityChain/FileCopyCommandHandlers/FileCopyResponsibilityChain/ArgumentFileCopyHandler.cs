using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCopyCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemPaths;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileCommandResponsibilityChain.FileCopyCommandHandlers.FileCopyResponsibilityChain;

public class ArgumentFileCopyHandler : FileCopyChainLinkBase
{
    public override ICommand Handle(Iterator iterator, FileCopyBuilder builder)
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