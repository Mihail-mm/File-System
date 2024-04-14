using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileMoveCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileCommandResponsibilityChain.FileMoveCommandHandlers.FileMoveResponsibilityChain;

public class FileMoveEndHandler : FileMoveChainLinkBase
{
    public override ICommand Handle(Iterator iterator, FileMoveBuilder builder)
    {
        return builder.Build();
    }
}