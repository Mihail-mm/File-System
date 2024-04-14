using System;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.TreeHandlers.TreeResponsibilityChain.TreeGotoHandlers.TreeGotoResponsibilityChain;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeGotoCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.TreeHandlers.TreeResponsibilityChain.TreeGotoHandlers;

public class TreeGotoHandler : TreeChainLinkBase
{
    private const string GotoCommand = "goto";
    private ITreeGotoChainLink _treeGotoChainLink;

    public TreeGotoHandler(ITreeGotoChainLink treeGotoChainLink)
    {
        _treeGotoChainLink = treeGotoChainLink;
    }

    public override ICommand Handle(Iterator iterator)
    {
        if (iterator.Current.Equals(GotoCommand, StringComparison.OrdinalIgnoreCase))
        {
            if (!iterator.MoveNext())
            {
                return new UnknownCommand();
            }

            var builder = new TreeGotoBuilder();
            return _treeGotoChainLink.Handle(iterator, builder);
        }

        return Next?.Handle(iterator) ?? new UnknownCommand();
    }
}