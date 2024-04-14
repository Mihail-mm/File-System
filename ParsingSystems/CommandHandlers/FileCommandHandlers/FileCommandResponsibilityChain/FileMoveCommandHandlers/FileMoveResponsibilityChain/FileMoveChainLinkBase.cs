using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileMoveCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileCommandResponsibilityChain.FileMoveCommandHandlers.FileMoveResponsibilityChain;

public abstract class FileMoveChainLinkBase : IFileMoveChainLink
{
    protected IFileMoveChainLink? Next { get; private set; }
    public void AddNext(IFileMoveChainLink link)
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

    public abstract ICommand Handle(Iterator iterator, FileMoveBuilder builder);
}