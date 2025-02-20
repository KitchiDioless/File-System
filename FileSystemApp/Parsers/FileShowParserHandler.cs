using FileSystemApp.Commands;
using System;

namespace FileSystemApp.Parsers;

public class FileShowParserHandler : ParserHandler
{
    public override ICommand Handle(string input)
    {
        string[] formattedString = FormatString(input);
        if (formattedString[0] == "file" && formattedString[1] == "show" && formattedString[3] == "-m")
        {
            return new FileShowCommand(formattedString[2], formattedString[4]);
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
