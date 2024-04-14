using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.DisconnectCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.DisconnectCommandHandlers;

public class DisconnectHandler : CommandChainLinkBase
{
    private const string Disconnect = "disconnect";

    public override ICommand Handle(Iterator iterator)
    {
        if (iterator.Current.Equals(Disconnect, StringComparison.OrdinalIgnoreCase))
        {
            return new DisconnectCommand();
        }

        return Next?.Handle(iterator) ?? new UnknownCommand();
    }
}