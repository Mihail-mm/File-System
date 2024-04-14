using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileCommandResponsibilityChain;

public interface IFileCommandChainLink
{
    void AddNext(IFileCommandChainLink link);
    ICommand Handle(Iterator iterator);
}