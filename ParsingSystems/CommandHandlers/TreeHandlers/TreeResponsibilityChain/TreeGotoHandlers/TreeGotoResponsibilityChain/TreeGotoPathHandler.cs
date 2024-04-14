using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeGotoCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemPaths;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.TreeHandlers.TreeResponsibilityChain.TreeGotoHandlers.TreeGotoResponsibilityChain;

public class TreeGotoPathHandler : TreeGotoChainLinkBase
{
    public override ICommand Handle(Iterator iterator, TreeGotoBuilder builder)
    {
        builder.WithPath(new FileSystemPath(iterator.Current));
        return Next?.Handle(iterator, builder) ?? new UnknownCommand();
    }
}