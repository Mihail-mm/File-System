using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileShowCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Drawers;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileCommandResponsibilityChain.FileShowCommandHandlers.FileShowResponsibilityChain;

public class FileShowModeHandler : FileShowChainLinkBase
{
    private const string Mode = "-m";
    private const string ConsoleMode = "Console";
    public override ICommand Handle(Iterator iterator, FileShowBuilder builder)
    {
        if (!iterator.Current.Equals(Mode, StringComparison.OrdinalIgnoreCase))
        {
            return Next?.Handle(iterator, builder) ?? new UnknownCommand();
        }

        if (!iterator.MoveNext())
        {
            return new UnknownCommand();
        }

        if (iterator.Current.Equals(ConsoleMode, StringComparison.OrdinalIgnoreCase))
        {
            builder.WithDrawer(new ConsoleDrawer());
        }

        return Next?.Handle(iterator, builder) ?? new UnknownCommand();
    }
}