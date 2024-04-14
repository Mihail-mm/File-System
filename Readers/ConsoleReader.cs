using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Readers;

public class ConsoleReader : IReader
{
    public IList<string> Read()
    {
        string? text = Console.ReadLine();
        if (text is not null)
        {
            return text.Split(" ").AsReadOnly();
        }

        return new List<string>();
    }
}