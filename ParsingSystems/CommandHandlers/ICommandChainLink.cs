using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers;

public interface ICommandChainLink
{
    void AddNext(ICommandChainLink link);
    ICommand Handle(Iterator iterator);
}