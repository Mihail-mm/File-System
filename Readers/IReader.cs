using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Readers;

public interface IReader
{
    IList<string> Read();
}