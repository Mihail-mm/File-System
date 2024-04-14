using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemComponents;

public class DirectoryComponent : IFileSystemComponent
{
    private readonly List<IFileSystemComponent> _components = new List<IFileSystemComponent>();
    public DirectoryComponent(string name)
    {
        Name = name;
    }

    public string Name { get; }
    public IReadOnlyCollection<IFileSystemComponent> Components => _components.AsReadOnly();

    public void Add(IFileSystemComponent component)
    {
        _components.Add(component);
    }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
        foreach (IFileSystemComponent component in _components)
        {
            component.Accept(visitor);
        }
    }
}