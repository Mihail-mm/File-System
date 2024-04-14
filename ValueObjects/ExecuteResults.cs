namespace Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

public abstract record ExecuteResults
{
    private ExecuteResults() { }

    public record Success : ExecuteResults;

    public record Failed : ExecuteResults;
}