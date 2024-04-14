using System;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.DisconnectCommands;

public class DisconnectCommand : ICommand
{
    public ExecuteResults Execute(Context context)
    {
        Environment.Exit(0);
        return new ExecuteResults.Success();
    }
}