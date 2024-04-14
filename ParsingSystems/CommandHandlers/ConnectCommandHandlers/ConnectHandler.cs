using System;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.ConnectCommandHandlers.ConnectCommandResponsibilityChain;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.ConnectCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.ConnectCommandHandlers;

public class ConnectHandler : CommandChainLinkBase
{
    private const string ConnectCommand = "connect";
    private readonly IConnectChainLink _connectLink;

    public ConnectHandler(IConnectChainLink link)
    {
        _connectLink = link;
    }

    public override ICommand Handle(Iterator iterator)
    {
        if (iterator.Current.Equals(ConnectCommand, StringComparison.OrdinalIgnoreCase))
        {
            if (!iterator.MoveNext())
            {
                return new UnknownCommand();
            }

            var builder = new ConnectCommandBuilder();
            return _connectLink.Handle(iterator, builder);
        }

        return Next?.Handle(iterator) ?? new UnknownCommand();
    }
}