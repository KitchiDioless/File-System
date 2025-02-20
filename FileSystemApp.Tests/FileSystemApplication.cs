using FileSystemApp.Commands;
using FileSystemApp.Parsers;
using Xunit;

namespace FileSystemApp.Tests;

public class FileSystemApplication
{
    [Fact]
    public void ConnectCommandTest_ShouldConnectToFileSystem_Success()
    {
        var parserChain = new ParserChain();
        ICommand command = parserChain.Parse("connect C:\\ -m local");

        Assert.IsType<ConnectCommand>(command);
    }

    [Fact]
    public void DisconnectCommandTest_ShouldDisconnect_Success()
    {
        var parserChain = new ParserChain();
        ICommand command = parserChain.Parse("connect C:\\ -m local");
        ICommand command2 = parserChain.Parse("disconnect");

        Assert.IsType<DisconnectCommand>(command2);
    }

    [Fact]
    public void TreeGotoCommandTest_ShouldChangePath_Success()
    {
        var parserChain = new ParserChain();
        ICommand command = parserChain.Parse("connect C:\\ -m local");
        ICommand command2 = parserChain.Parse("tree goto Users\\");

        Assert.IsType<TreeGotoCommand>(command2);
    }

    [Fact]
    public void TreeListCommandTest_ShouldShowTreeOfFiles_Success()
    {
        var parserChain = new ParserChain();
        ICommand command = parserChain.Parse("connect C:\\Users\\ -m local");
        ICommand command2 = parserChain.Parse("tree list -d 1");

        Assert.IsType<TreeListCommand>(command2);
    }

    [Fact]
    public void FileMoveCommandTest_ShouldMoveFile_Success()
    {
        var parserChain = new ParserChain();
        ICommand command = parserChain.Parse("connect C:\\Users\\dusti\\ -m local");
        ICommand command2 = parserChain.Parse("file move test1.txt testDir\\test1.txt");

        Assert.IsType<FileMoveCommand>(command2);
    }

    [Fact]
    public void FileCopyCommandTest_ShouldCopyFile_Success()
    {
        var parserChain = new ParserChain();
        ICommand command = parserChain.Parse("connect C:\\Users\\dusti\\ -m local");
        ICommand command2 = parserChain.Parse("file copy test1.txt testDir\\test1.txt");

        Assert.IsType<FileCopyCommand>(command2);
    }

    [Fact]
    public void FileDeleteCommandTest_ShouldDeleteFile_Success()
    {
        var parserChain = new ParserChain();
        ICommand command = parserChain.Parse("connect C:\\Users\\dusti\\ -m local");
        ICommand command2 = parserChain.Parse("file delete test1.txt");

        Assert.IsType<FileDeleteCommand>(command2);
    }

    [Fact]
    public void FileRenameCommandTest_ShouldCopyFile_Success()
    {
        var parserChain = new ParserChain();
        ICommand command = parserChain.Parse("connect C:\\Users\\dusti\\ -m local");
        ICommand command2 = parserChain.Parse("file rename test1.txt notTest1.txt");

        Assert.IsType<FileRenameCommand>(command2);
    }

    [Fact]
    public void FileShowCommandTest_ShouldShowFileContent_Success()
    {
        var parserChain = new ParserChain();
        ICommand command = parserChain.Parse("connect C:\\Users\\dusti\\ -m local");
        ICommand command2 = parserChain.Parse("file show test.txt -m console");

        Assert.IsType<FileShowCommand>(command2);
    }
}
