using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeGotoCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.TreeHandlers.TreeResponsibilityChain.TreeGotoHandlers.TreeGotoResponsibilityChain;

public interface ITreeGotoChainLink
{
    void AddNext(ITreeGotoChainLink link);
    ICommand Handle(Iterator iterator, TreeGotoBuilder builder);
}