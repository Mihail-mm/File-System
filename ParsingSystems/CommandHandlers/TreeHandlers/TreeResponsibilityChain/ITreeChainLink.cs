using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.TreeHandlers.TreeResponsibilityChain;

public interface ITreeChainLink
{
    void AddNext(ITreeChainLink link);
    ICommand Handle(Iterator iterator);
}