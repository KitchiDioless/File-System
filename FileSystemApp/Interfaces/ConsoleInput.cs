using System;

namespace FileSystemApp.Interfaces;

public class ConsoleInput : IInput
{
    public string ReadInput()
    {
        return Console.ReadLine() ?? string.Empty;
    }
}
