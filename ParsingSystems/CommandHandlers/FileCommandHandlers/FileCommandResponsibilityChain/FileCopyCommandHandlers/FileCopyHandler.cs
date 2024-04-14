using System;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileCommandResponsibilityChain.FileCopyCommandHandlers.FileCopyResponsibilityChain;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCopyCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileCommandResponsibilityChain.FileCopyCommandHandlers;

public class FileCopyHandler : FileCommandChainLinkBase
{
    private const string FileCopyCommand = "copy";
    private IFileCopyChainLink _filePathHandlers;

    public FileCopyHandler(IFileCopyChainLink filePathHandlers)
    {
        _filePathHandlers = filePathHandlers;
    }

    public override ICommand Handle(Iterator iterator)
    {
        if (iterator.Current.Equals(FileCopyCommand, StringComparison.OrdinalIgnoreCase))
        {
            if (!iterator.MoveNext())
            {
                return new UnknownCommand();
            }

            var builder = new FileCopyBuilder();
            return _filePathHandlers.Handle(iterator, builder);
        }

        return Next?.Handle(iterator) ?? new UnknownCommand();
    }
}