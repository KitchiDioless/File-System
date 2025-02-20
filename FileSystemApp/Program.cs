using FileSystemApp.Commands;
using FileSystemApp.Interfaces;
using System;

namespace FileSystemApp;

public class Program
{
    public static void Main()
    {
        var consoleInput = new ConsoleInput();
        var consoleOutput = new ConsoleOutput();
        var parserChain = new FileSystemApp.Parsers.ParserChain();

        while (true)
        {
            string input = consoleInput.ReadInput();

            if (input == "exit")
            {
                consoleOutput.WriteOutput("Exiting program...");
                break;
            }

            try
            {
                ICommand command = parserChain.Parse(input);

                string result = command.Execute();
                consoleOutput.WriteOutput(result);
            }
            catch (Exception ex)
            {
                consoleOutput.WriteOutput($"Error: {ex.Message}");
            }
        }
    }
}
