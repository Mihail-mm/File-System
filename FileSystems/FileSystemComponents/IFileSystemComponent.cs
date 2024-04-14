using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemComponents;

public interface IFileSystemComponent
{
    string Name { get; }
    void Accept(IVisitor visitor);
}