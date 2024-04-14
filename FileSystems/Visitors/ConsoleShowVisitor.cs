using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemComponents;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Visitors;

public class ConsoleShowVisitor : IVisitor
{
    private readonly int _maxDepth;
    private int _currentDepth;

    public ConsoleShowVisitor(int maxDepth)
    {
        _maxDepth = maxDepth;
    }

    public void Visit(FileComponent file)
    {
        Print(file.Name);
    }

    public void Visit(DirectoryComponent directory)
    {
        Print(directory.Name);
        _currentDepth++;
        if (_currentDepth <= _maxDepth)
        {
            foreach (IFileSystemComponent component in directory.Components)
            {
                component.Accept(this);
            }
        }

        _currentDepth--;
    }

    private void Print(string name)
    {
        Console.WriteLine(new string('\t', _currentDepth) + name);
    }
}