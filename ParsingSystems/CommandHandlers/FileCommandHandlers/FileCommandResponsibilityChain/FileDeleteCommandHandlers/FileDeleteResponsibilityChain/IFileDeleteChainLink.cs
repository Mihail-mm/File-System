using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileDeleteCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileCommandResponsibilityChain.FileDeleteCommandHandlers.FileDeleteResponsibilityChain;

public interface IFileDeleteChainLink
{
    void AddNext(IFileDeleteChainLink link);
    ICommand Handle(Iterator iterator, FileDeleteBuilder builder);
}