using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.ConnectCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemPaths;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.ConnectCommandHandlers.ConnectCommandResponsibilityChain;

public class ConnectAddressHandler : ConnectChainLinkBase
{
    public override ICommand Handle(Iterator iterator, ConnectCommandBuilder builder)
    {
        builder.WithPath(new FileSystemPath(iterator.Current));
        return Next?.Handle(iterator, builder) ?? new UnknownCommand();
    }
}