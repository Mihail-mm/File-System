using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.ConnectCommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.ConnectCommandHandlers.ConnectCommandResponsibilityChain;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.DisconnectCommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileCommandResponsibilityChain;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileCommandResponsibilityChain.FileCopyCommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileCommandResponsibilityChain.FileCopyCommandHandlers.FileCopyResponsibilityChain;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileCommandResponsibilityChain.FileDeleteCommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileCommandResponsibilityChain.FileDeleteCommandHandlers.FileDeleteResponsibilityChain;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileCommandResponsibilityChain.FileMoveCommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileCommandResponsibilityChain.FileMoveCommandHandlers.FileMoveResponsibilityChain;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileCommandResponsibilityChain.FileRenameCommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileCommandResponsibilityChain.FileRenameCommandHandlers.FileRenameResponsibilityChain;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileCommandResponsibilityChain.FileShowCommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileCommandResponsibilityChain.FileShowCommandHandlers.FileShowResponsibilityChain;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.TreeHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.TreeHandlers.TreeResponsibilityChain;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.TreeHandlers.TreeResponsibilityChain.TreeGotoHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.TreeHandlers.TreeResponsibilityChain.TreeGotoHandlers.TreeGotoResponsibilityChain;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.TreeHandlers.TreeResponsibilityChain.TreeListHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.TreeHandlers.TreeResponsibilityChain.TreeListHandlers.TreeListResponsibilityChain;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParsingSystems;

public class ParsingSystem : IParsingSystem
{
    public ICommand Parse(Iterator iterator)
    {
        // link for Connect
        IConnectChainLink linkConnectAddress = new ConnectAddressHandler();
        IConnectChainLink linkConnectMode = new ConnectModeHandler();
        IConnectChainLink linkConnectEnd = new ConnectEndHandler();
        linkConnectAddress.AddNext(linkConnectMode);
        linkConnectMode.AddNext(linkConnectEnd);

        // link for tree list
        ITreeListChainLink treeListDepth = new TreeListDepthHandler();
        ITreeListChainLink treeListEnd = new TreeListEndHandler();
        treeListDepth.AddNext(treeListEnd);

        // link for tree goto
        ITreeGotoChainLink treeGotoPath = new TreeGotoPathHandler();
        ITreeGotoChainLink treeGotoEnd = new TreeGotoEndHandler();
        treeGotoPath.AddNext(treeGotoEnd);

        // link for File Copy
        IFileCopyChainLink fileCopyArgument = new ArgumentFileCopyHandler();
        IFileCopyChainLink fileCopyEnd = new FileCopyEndHandler();
        fileCopyArgument.AddNext(fileCopyEnd);

        // link for File Delete
        IFileDeleteChainLink fileDeletePath = new FileDeletePathHandler();
        IFileDeleteChainLink fileDeleteEnd = new FileDeleteEndHandler();
        fileDeletePath.AddNext(fileDeleteEnd);

        // link for File Move
        IFileMoveChainLink fileMovePath = new FileMovePathHandler();
        IFileMoveChainLink fileMoveEnd = new FileMoveEndHandler();
        fileMovePath.AddNext(fileMoveEnd);

        // link for File Rename
        IFileRenameChainLink fileRenamePath = new FileRenamePath();
        IFileRenameChainLink fileRenameName = new FileRenameNewNameHandler();
        IFileRenameChainLink fileRenameEnd = new FileRenameEnd();
        fileRenamePath.AddNext(fileRenameName);
        fileRenameName.AddNext(fileRenameEnd);

        // link for File Show
        IFileShowChainLink fileShowPath = new FileShowPathHandler();
        IFileShowChainLink fileSHowEnd = new FileShowEndHandler();
        fileShowPath.AddNext(fileSHowEnd);

        // link for file
        IFileCommandChainLink fileCopy = new FileCopyHandler(fileCopyArgument);
        IFileCommandChainLink fileDelete = new FileDeleteHandler(fileDeletePath);
        IFileCommandChainLink fileMove = new FileMoveHandler(fileMovePath);
        IFileCommandChainLink fileRename = new FileRenameHandler(fileRenamePath);
        IFileCommandChainLink fileShow = new FileShowHandler(fileShowPath);
        fileCopy.AddNext(fileDelete);
        fileDelete.AddNext(fileMove);
        fileMove.AddNext(fileRename);
        fileRename.AddNext(fileShow);

        // link for tree
        ITreeChainLink treeList = new TreeListHandler(treeListDepth);
        ITreeChainLink treeGoto = new TreeGotoHandler(treeGotoPath);
        treeList.AddNext(treeGoto);

        // Main Commands
        ICommandChainLink linkConnect = new ConnectHandler(linkConnectAddress);
        ICommandChainLink linkDisconnect = new DisconnectHandler();
        ICommandChainLink linkFile = new FileHandler(fileCopy);
        ICommandChainLink linkTree = new TreeHandler(treeList);
        linkConnect.AddNext(linkDisconnect);
        linkDisconnect.AddNext(linkFile);
        linkFile.AddNext(linkTree);
        return linkConnect.Handle(iterator);
    }
}