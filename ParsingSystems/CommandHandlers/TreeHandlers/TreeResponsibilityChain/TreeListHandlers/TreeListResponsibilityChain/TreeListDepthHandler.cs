using System;
using System.Globalization;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.TreeHandlers.TreeResponsibilityChain.TreeListHandlers.TreeListResponsibilityChain;

public class TreeListDepthHandler : TreeListChainLinkBase
{
    private const string FlagDepth = "-d";
    public override ICommand Handle(Iterator iterator, TreeListBuilder builder)
    {
        if (iterator.Current.Equals(FlagDepth, StringComparison.OrdinalIgnoreCase))
        {
            if (!iterator.MoveNext())
            {
                return new UnknownCommand();
            }

            builder.WithDepth(Convert.ToInt32(iterator.Current, new CultureInfo(1)));
            return Next?.Handle(iterator, builder) ?? new UnknownCommand();
        }

        return new UnknownCommand();
    }
}