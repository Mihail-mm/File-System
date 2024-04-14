using System;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.TreeHandlers.TreeResponsibilityChain.TreeListHandlers.TreeListResponsibilityChain;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.TreeHandlers.TreeResponsibilityChain.TreeListHandlers;

public class TreeListHandler : TreeChainLinkBase
{
    private const string ListCommand = "list";
    private ITreeListChainLink _treeListChainLink;

    public TreeListHandler(ITreeListChainLink treeListChainLink)
    {
        _treeListChainLink = treeListChainLink;
    }

    public override ICommand Handle(Iterator iterator)
    {
        if (iterator.Current.Equals(ListCommand, StringComparison.OrdinalIgnoreCase))
        {
            var builder = new TreeListBuilder();
            if (!iterator.MoveNext())
            {
                return builder.Build();
            }

            return _treeListChainLink.Handle(iterator, builder);
        }

        return Next?.Handle(iterator) ?? new UnknownCommand();
    }
}