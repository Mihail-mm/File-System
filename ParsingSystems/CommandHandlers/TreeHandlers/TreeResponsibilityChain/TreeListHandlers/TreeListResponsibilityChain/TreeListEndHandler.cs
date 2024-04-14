using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.TreeHandlers.TreeResponsibilityChain.TreeListHandlers.TreeListResponsibilityChain;

public class TreeListEndHandler : TreeListChainLinkBase
{
    public override ICommand Handle(Iterator iterator, TreeListBuilder builder)
    {
        return builder.Build();
    }
}