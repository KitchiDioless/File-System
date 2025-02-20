using FileSystemApp.Commands;
using System;

namespace FileSystemApp.Parsers;

public class TreeListParserHandler : ParserHandler
{
    public override ICommand Handle(string input)
    {
        string[] formattedString = FormatString(input);
        if (formattedString[0] == "tree" && formattedString[1] == "list" && formattedString[2] == "-d")
        {
             return new TreeListCommand(int.Parse(formattedString[3]));
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
