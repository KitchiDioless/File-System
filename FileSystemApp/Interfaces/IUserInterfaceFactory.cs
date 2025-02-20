namespace FileSystemApp.Interfaces;

public interface IUserInterfaceFactory
{
    IInput CreateInput();

    IOutput CreateOutput();
}
