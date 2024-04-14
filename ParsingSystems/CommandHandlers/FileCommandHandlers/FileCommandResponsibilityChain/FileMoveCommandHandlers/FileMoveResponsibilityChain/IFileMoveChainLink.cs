using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileMoveCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileCommandResponsibilityChain.FileMoveCommandHandlers.FileMoveResponsibilityChain;

public interface IFileMoveChainLink
{
    void AddNext(IFileMoveChainLink link);
    ICommand Handle(Iterator iterator, FileMoveBuilder builder);
}