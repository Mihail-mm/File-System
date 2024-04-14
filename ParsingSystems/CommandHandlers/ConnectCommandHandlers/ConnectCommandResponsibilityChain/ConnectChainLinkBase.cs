using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.ConnectCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.ConnectCommandHandlers.ConnectCommandResponsibilityChain;

public abstract class ConnectChainLinkBase : IConnectChainLink
{
    protected IConnectChainLink? Next { get; private set;  }

    public void AddNext(IConnectChainLink link)
    {
        if (Next is null)
        {
            Next = link;
        }
        else
        {
            Next.AddNext(link);
        }
    }

    public abstract ICommand Handle(Iterator iterator, ConnectCommandBuilder builder);
}