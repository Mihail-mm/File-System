using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Drawers;

public class ConsoleDrawer : IDrawer
{
    public void Print(string text)
    {
        Console.WriteLine(text);
    }
}