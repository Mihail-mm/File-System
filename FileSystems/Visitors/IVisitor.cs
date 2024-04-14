using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.FileSystemComponents;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Visitors;

public interface IVisitor
{
    void Visit(FileComponent file);
    void Visit(DirectoryComponent directory);
}