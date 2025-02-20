using FileSystemApp.Commands;

namespace FileSystemApp.Parsers;

public abstract class ParserHandler
{
    public ParserHandler? NextHandler { get; private set; }

    public void SetNextHandler(ParserHandler nextHandler)
    {
        NextHandler = nextHandler;
    }

    public string[] FormatString(string input)
    {
        return input.ToLowerInvariant().Split(" ");
    }

    public abstract ICommand Handle(string input);
}
