using System;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileCommandResponsibilityChain.FileRenameCommandHandlers.FileRenameResponsibilityChain;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileRenameCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileCommandResponsibilityChain.FileRenameCommandHandlers;

public class FileRenameHandler : FileCommandChainLinkBase
{
    private const string RenameCommand = "rename";
    private IFileRenameChainLink _fileRenameChainLink;

    public FileRenameHandler(IFileRenameChainLink fileRenameChainLink)
    {
        _fileRenameChainLink = fileRenameChainLink;
    }

    public override ICommand Handle(Iterator iterator)
    {
        if (iterator.Current.Equals(RenameCommand, StringComparison.OrdinalIgnoreCase))
        {
            var builder = new FileRenameBuilder();
            if (!iterator.MoveNext())
            {
                return new UnknownCommand();
            }

            return _fileRenameChainLink.Handle(iterator, builder);
        }

        return Next?.Handle(iterator) ?? new UnknownCommand();
    }
}