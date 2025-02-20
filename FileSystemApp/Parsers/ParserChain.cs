using FileSystemApp.Commands;

namespace FileSystemApp.Parsers;

public class ParserChain
{
    private readonly ParserHandler _headParser;

    public ParserChain()
    {
        _headParser = new ConnectParserHandler();

        var disconnectParserHandler = new DisconnectParserHandler();
        var fileCopyParserHandler = new FileCopyParserHandler();
        var fileDeleteParserHandler = new FileDeleteParserHandler();
        var fileMoveParserHandler = new FileMoveParserHandler();
        var fileRenameParserHandler = new FileRenameParserHandler();
        var fileShowParserHandler = new FileShowParserHandler();
        var treeListParserHandler = new TreeListParserHandler();
        var treeGotoParserHandler = new TreeGotoParserHandler();

        _headParser.SetNextHandler(disconnectParserHandler);
        disconnectParserHandler.SetNextHandler(fileCopyParserHandler);
        fileCopyParserHandler.SetNextHandler(fileDeleteParserHandler);
        fileDeleteParserHandler.SetNextHandler(fileMoveParserHandler);
        fileMoveParserHandler.SetNextHandler(fileRenameParserHandler);
        fileRenameParserHandler.SetNextHandler(fileShowParserHandler);
        fileShowParserHandler.SetNextHandler(treeListParserHandler);
        treeListParserHandler.SetNextHandler(treeGotoParserHandler);
    }

    public ICommand Parse(string input)
    {
        return _headParser.Handle(input);
    }
}
