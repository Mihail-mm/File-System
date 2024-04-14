using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeGotoCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.TreeHandlers.TreeResponsibilityChain.TreeGotoHandlers.TreeGotoResponsibilityChain;

public class TreeGotoEndHandler : TreeGotoChainLinkBase
{
    public override ICommand Handle(Iterator iterator, TreeGotoBuilder builder)
    {
        return builder.Build();
    }
}