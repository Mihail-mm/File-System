namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeListCommands;

public class TreeListBuilder
{
    private int? _depth;

    public void WithDepth(int depth)
    {
        _depth = depth;
    }

    public ICommand Build()
    {
        return new TreeListCommand(_depth ??= 1);
    }
}