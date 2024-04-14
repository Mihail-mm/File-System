using System;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileCommandResponsibilityChain.FileDeleteCommandHandlers.FileDeleteResponsibilityChain;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileDeleteCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileCommandResponsibilityChain.FileDeleteCommandHandlers;

public class FileDeleteHandler : FileCommandChainLinkBase
{
    private const string FileDeleteCommand = "delete";
    private IFileDeleteChainLink _fileDeleteChainLink;

    public FileDeleteHandler(IFileDeleteChainLink fileDeleteChainLink)
    {
        _fileDeleteChainLink = fileDeleteChainLink;
    }

    public override ICommand Handle(Iterator iterator)
    {
        if (iterator.Current.Equals(FileDeleteCommand, StringComparison.OrdinalIgnoreCase))
        {
            if (!iterator.MoveNext())
            {
                return new UnknownCommand();
            }

            var builder = new FileDeleteBuilder();
            return _fileDeleteChainLink.Handle(iterator, builder);
        }

        return Next?.Handle(iterator) ?? new UnknownCommand();
    }
}