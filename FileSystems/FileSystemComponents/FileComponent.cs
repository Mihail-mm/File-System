using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemComponents;

public class FileComponent : IFileSystemComponent
{
    public FileComponent(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}
