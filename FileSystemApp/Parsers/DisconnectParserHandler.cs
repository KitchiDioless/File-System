using FileSystemApp.Commands;
using System;

namespace FileSystemApp.Parsers;

public class DisconnectParserHandler : ParserHandler
{
    public override ICommand Handle(string input)
    {
        string[] formattedString = FormatString(input);
        if (formattedString[0] == "disconnect")
        {
            return new DisconnectCommand();
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
