using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.TreeHandlers.TreeResponsibilityChain.TreeListHandlers.TreeListResponsibilityChain;

public interface ITreeListChainLink
{
    void AddNext(ITreeListChainLink link);
    ICommand Handle(Iterator iterator, TreeListBuilder builder);
}