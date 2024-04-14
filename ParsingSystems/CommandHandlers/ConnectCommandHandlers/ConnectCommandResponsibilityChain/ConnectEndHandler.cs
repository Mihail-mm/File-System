using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.ConnectCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.ConnectCommandHandlers.ConnectCommandResponsibilityChain;

public class ConnectEndHandler : ConnectChainLinkBase
{
    public override ICommand Handle(Iterator iterator, ConnectCommandBuilder builder)
    {
        return builder.Build();
    }
}