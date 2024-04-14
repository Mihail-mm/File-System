using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileRenameCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileCommandResponsibilityChain.FileRenameCommandHandlers.FileRenameResponsibilityChain;

public abstract class FileRenameChainLinkBase : IFileRenameChainLink
{
    protected IFileRenameChainLink? Next { get; private set; }
    public void AddNext(IFileRenameChainLink link)
    {
        if (Next is null)
        {
            Next = link;
        }
        else
        {
            Next.AddNext(link);
        }
    }

    public abstract ICommand Handle(Iterator iterator, FileRenameBuilder builder);
}