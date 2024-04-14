using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCopyCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileCommandResponsibilityChain.FileCopyCommandHandlers.FileCopyResponsibilityChain;

public abstract class FileCopyChainLinkBase : IFileCopyChainLink
{
    protected IFileCopyChainLink? Next { get; private set; }
    public void AddNext(IFileCopyChainLink link)
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

    public abstract ICommand Handle(Iterator iterator, FileCopyBuilder builder);
}