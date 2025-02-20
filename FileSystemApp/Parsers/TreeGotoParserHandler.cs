using FileSystemApp.Commands;
using System;

namespace FileSystemApp.Parsers;

public class TreeGotoParserHandler : ParserHandler
{
    public override ICommand Handle(string input)
    {
        string[] formattedString = FormatString(input);
        if (formattedString[0] == "tree" && formattedString[1] == "goto")
        {
            return new TreeGotoCommand(formattedString[2]);
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
