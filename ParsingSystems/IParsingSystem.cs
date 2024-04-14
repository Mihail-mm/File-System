using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParsingSystems;

public interface IParsingSystem
{
    ICommand Parse(Iterator iterator);
}