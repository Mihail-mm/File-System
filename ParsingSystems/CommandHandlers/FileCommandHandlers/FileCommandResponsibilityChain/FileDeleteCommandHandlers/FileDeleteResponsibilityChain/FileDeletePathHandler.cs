using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileDeleteCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemPaths;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileCommandResponsibilityChain.FileDeleteCommandHandlers.FileDeleteResponsibilityChain;

public class FileDeletePathHandler : FileDeleteChainLinkBase
{
    public override ICommand Handle(Iterator iterator, FileDeleteBuilder builder)
    {
        builder.WithPath(new FileSystemPath(iterator.Current));
        return Next?.Handle(iterator, builder) ?? new UnknownCommand();
    }
}