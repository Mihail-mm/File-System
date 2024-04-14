using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileCommandResponsibilityChain;

public abstract class FileCommandChainLinkBase : IFileCommandChainLink
{
    protected IFileCommandChainLink? Next { get; private set; }
    public void AddNext(IFileCommandChainLink link)
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

    public abstract ICommand Handle(Iterator iterator);
}