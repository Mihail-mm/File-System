using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers;

public abstract class CommandChainLinkBase : ICommandChainLink
{
    protected ICommandChainLink? Next { get; private set;  }

    public void AddNext(ICommandChainLink link)
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