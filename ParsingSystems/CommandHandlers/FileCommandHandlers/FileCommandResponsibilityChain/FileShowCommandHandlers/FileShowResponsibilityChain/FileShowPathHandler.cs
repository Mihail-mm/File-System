using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileShowCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemPaths;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileCommandResponsibilityChain.FileShowCommandHandlers.FileShowResponsibilityChain;

public class FileShowPathHandler : FileShowChainLinkBase
{
    public override ICommand Handle(Iterator iterator, FileShowBuilder builder)
    {
        builder.WithPath(new FileSystemPath(iterator.Current));
        return Next?.Handle(iterator, builder) ?? new UnknownCommand();
    }
}