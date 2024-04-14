using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileDeleteCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileCommandResponsibilityChain.FileDeleteCommandHandlers.FileDeleteResponsibilityChain;

public abstract class FileDeleteChainLinkBase : IFileDeleteChainLink
{
    protected IFileDeleteChainLink? Next { get; private set; }
    public void AddNext(IFileDeleteChainLink link)
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

    public abstract ICommand Handle(Iterator iterator, FileDeleteBuilder builder);
}