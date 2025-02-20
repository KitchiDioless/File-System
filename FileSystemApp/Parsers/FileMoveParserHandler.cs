using FileSystemApp.Commands;
using System;

namespace FileSystemApp.Parsers;

public class FileMoveParserHandler : ParserHandler
{
    public override ICommand Handle(string input)
    {
        string[] formattedString = FormatString(input);
        if (formattedString[0] == "file" && formattedString[1] == "move")
        {
            return new FileMoveCommand(formattedString[2], formattedString[3]);
        }
        else
        {
            if (NextHandler?.Handle(input) != null)
            {
                return NextHandler.Handle(input);
            }

            throw new Exception("Unknown command");
        }
    }
}
