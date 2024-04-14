using System;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.TreeHandlers.TreeResponsibilityChain;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.TreeHandlers;

public class TreeHandler : CommandChainLinkBase
{
    private const string TreeCommand = "tree";
    private ITreeChainLink _treeChainLink;

    public TreeHandler(ITreeChainLink treeChainLink)
    {
        _treeChainLink = treeChainLink;
    }

    public override ICommand Handle(Iterator iterator)
    {
        if (iterator.Current.Equals(TreeCommand, StringComparison.OrdinalIgnoreCase))
        {
            if (!iterator.MoveNext())
            {
                return new UnknownCommand();
            }

            return _treeChainLink.Handle(iterator);
        }

        return Next?.Handle(iterator) ?? new UnknownCommand();
    }
}