using System;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileCommandResponsibilityChain.FileShowCommandHandlers.FileShowResponsibilityChain;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileShowCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileCommandResponsibilityChain.FileShowCommandHandlers;

public class FileShowHandler : FileCommandChainLinkBase
{
    private const string ShowCommand = "show";
    private IFileShowChainLink _fileShowChainLink;

    public FileShowHandler(IFileShowChainLink fileShowChainLink)
    {
        _fileShowChainLink = fileShowChainLink;
    }

    public override ICommand Handle(Iterator iterator)
    {
        if (iterator.Current.Equals(ShowCommand, StringComparison.OrdinalIgnoreCase))
        {
            if (!iterator.MoveNext())
            {
                return new UnknownCommand();
            }

            var builder = new FileShowBuilder();
            return _fileShowChainLink.Handle(iterator, builder);
        }

        return Next?.Handle(iterator) ?? new UnknownCommand();
    }
}