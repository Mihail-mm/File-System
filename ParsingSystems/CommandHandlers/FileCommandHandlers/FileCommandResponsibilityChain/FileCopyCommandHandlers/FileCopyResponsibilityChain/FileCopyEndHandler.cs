using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCopyCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileCommandResponsibilityChain.FileCopyCommandHandlers.FileCopyResponsibilityChain;

public class FileCopyEndHandler : FileCopyChainLinkBase
{
    public override ICommand Handle(Iterator iterator, FileCopyBuilder builder)
    {
        return builder.Build();
    }
}