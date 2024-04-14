using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileShowCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileCommandResponsibilityChain.FileShowCommandHandlers.FileShowResponsibilityChain;

public class FileShowEndHandler : FileShowChainLinkBase
{
    public override ICommand Handle(Iterator iterator, FileShowBuilder builder)
    {
        return builder.Build();
    }
}