using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.ConnectCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.ConnectCommandHandlers.ConnectCommandResponsibilityChain;

public class ConnectModeHandler : ConnectChainLinkBase
{
    private const string ModeFlag = "-m";
    private const string LocalMode = "Local";
    public override ICommand Handle(Iterator iterator, ConnectCommandBuilder builder)
    {
        if (iterator.Current.Equals(ModeFlag, StringComparison.OrdinalIgnoreCase))
        {
            if (!iterator.MoveNext())
            {
                return new UnknownCommand();
            }

            if (iterator.Current.Equals(LocalMode, StringComparison.OrdinalIgnoreCase))
            {
                builder.WithFileSystem(new LocalFileSystem());
            }
        }

        return Next?.Handle(iterator, builder) ?? new UnknownCommand();
    }
}