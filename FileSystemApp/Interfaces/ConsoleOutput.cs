using System;

namespace FileSystemApp.Interfaces;

public class ConsoleOutput : IOutput
{
    public void WriteOutput(string output)
    {
        Console.WriteLine(output);
    }
}
