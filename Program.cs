using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;
using Itmo.ObjectOrientedProgramming.Lab4.ParsingSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Readers;
using Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public static class Program
{
    public static void Main()
    {
        IParsingSystem parsingSystem = new ParsingSystem();
        var context = new Context();
        IReader reader = new ConsoleReader();
        while (true)
        {
            ICommand command = parsingSystem.Parse(new Iterator(reader.Read()));
            ExecuteResults result = command.Execute(context);
            if (result is not ExecuteResults.Success)
            {
                Console.WriteLine("Error");
            }
        }
    }
}