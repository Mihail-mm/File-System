using System;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileCommandResponsibilityChain;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers;

public class FileHandler : CommandChainLinkBase
{
    private const string FileCommand = "file";
    private readonly IFileCommandChainLink _fileCommandChainLink;

    public FileHandler(IFileCommandChainLink fileCommandChainLink)
    {
        _fileCommandChainLink = fileCommandChainLink;
    }

    public override ICommand Handle(Iterator iterator)
    {
        if (iterator.Current.Equals(FileCommand, StringComparison.OrdinalIgnoreCase))
        {
            if (!iterator.MoveNext())
            {
                return new UnknownCommand();
            }

            return _fileCommandChainLink.Handle(iterator);
        }

        return Next?.Handle(iterator) ?? new UnknownCommand();
    }
}