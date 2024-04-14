using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileRenameCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileCommandResponsibilityChain.FileRenameCommandHandlers.FileRenameResponsibilityChain;

public interface IFileRenameChainLink
{
    void AddNext(IFileRenameChainLink link);
    ICommand Handle(Iterator iterator, FileRenameBuilder builder);
}