using FileSystemApp.Commands;
using System;

namespace FileSystemApp.Parsers;

public class ConnectParserHandler : ParserHandler
{
    public override ICommand Handle(string input)
    {
        string[] formattedString = FormatString(input);
        if (formattedString[0] == "connect" && formattedString[2] == "-m")
        {
            return new ConnectCommand(formattedString[1], formattedString[3]);
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
