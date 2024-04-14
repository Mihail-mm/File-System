using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.ConnectCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.ConnectCommandHandlers.ConnectCommandResponsibilityChain;

public interface IConnectChainLink
{
    void AddNext(IConnectChainLink link);
    ICommand Handle(Iterator iterator, ConnectCommandBuilder builder);
}