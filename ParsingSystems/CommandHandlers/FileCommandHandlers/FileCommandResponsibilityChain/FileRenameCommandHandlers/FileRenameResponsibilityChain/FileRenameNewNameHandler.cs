using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileRenameCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileCommandResponsibilityChain.FileRenameCommandHandlers.FileRenameResponsibilityChain;

public class FileRenameNewNameHandler : FileRenameChainLinkBase
{
    public override ICommand Handle(Iterator iterator, FileRenameBuilder builder)
    {
        builder.WithName(iterator.Current);
        return Next?.Handle(iterator, builder) ?? new UnknownCommand();
    }
}