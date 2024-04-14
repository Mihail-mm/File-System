using System;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileCommandResponsibilityChain.FileMoveCommandHandlers.FileMoveResponsibilityChain;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileMoveCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileCommandResponsibilityChain.FileMoveCommandHandlers;

public class FileMoveHandler : FileCommandChainLinkBase
{
    private const string FileMoveCommand = "move";
    private IFileMoveChainLink _fileMoveChainLink;

    public FileMoveHandler(IFileMoveChainLink fileMoveChainLink)
    {
        _fileMoveChainLink = fileMoveChainLink;
    }

    public override ICommand Handle(Iterator iterator)
    {
        if (iterator.Current.Equals(FileMoveCommand, StringComparison.OrdinalIgnoreCase))
        {
            if (!iterator.MoveNext())
            {
                return new UnknownCommand();
            }

            var builder = new FileMoveBuilder();
            return _fileMoveChainLink.Handle(iterator, builder);
        }

        return Next?.Handle(iterator) ?? new UnknownCommand();
    }
}