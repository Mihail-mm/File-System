using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeGotoCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.TreeHandlers.TreeResponsibilityChain.TreeGotoHandlers.TreeGotoResponsibilityChain;

public abstract class TreeGotoChainLinkBase : ITreeGotoChainLink
{
    protected ITreeGotoChainLink? Next { get; private set; }
    public void AddNext(ITreeGotoChainLink link)
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

    public abstract ICommand Handle(Iterator iterator, TreeGotoBuilder builder);
}