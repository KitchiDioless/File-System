using FileSystemApp.Commands;
using System;

namespace FileSystemApp.Parsers;

public class FileDeleteParserHandler : ParserHandler
{
    public override ICommand Handle(string input)
    {
        string[] formattedString = FormatString(input);
        if (formattedString[0] == "file" && formattedString[1] == "delete")
        {
            return new FileDeleteCommand(formattedString[2]);
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
