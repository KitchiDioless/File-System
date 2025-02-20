namespace FileSystemApp.Interfaces;

public class ConsoleUserInterfaceFactory : IUserInterfaceFactory
{
    public IInput CreateInput()
    {
        return new ConsoleInput();
    }

    public IOutput CreateOutput()
    {
        return new ConsoleOutput();
    }
}
