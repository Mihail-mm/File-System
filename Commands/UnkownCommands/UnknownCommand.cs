using System;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class UnknownCommand : ICommand
{
    public ExecuteResults Execute(Context context)
    {
        Console.WriteLine("Unknown Command");
        return new ExecuteResults.Success();
    }
}