using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemPaths;
using Itmo.ObjectOrientedProgramming.Lab4.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCopyCommands;

public class FileCopyCommand : ICommand
{
    private readonly IFileSystemPath _soursePath;
    private readonly IFileSystemPath _destinationPath;

    public FileCopyCommand(IFileSystemPath soursePath, IFileSystemPath destinationPath)
    {
        _soursePath = soursePath;
        _destinationPath = destinationPath;
    }

    public ExecuteResults Execute(Context context)
    {
        if (context.FileSystem is not null && context.FileSystem.PathIsCorrect(_soursePath) && context.FileSystem.PathIsCorrect(_destinationPath))
        {
            context.FileSystem.CopyFile(_soursePath, _destinationPath);
            return new ExecuteResults.Success();
        }

        return new ExecuteResults.Failed();
    }
}