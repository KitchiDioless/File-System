using FileSystemApp.ApplicationStates;

namespace FileSystemApp.Commands;

public class FileMoveCommand : ICommand
{
    private readonly string _sourcePath;

    private readonly string _destinationPath;

    public FileMoveCommand(string sourcePath, string destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public string Execute()
    {
        if (ApplicationState.Instance.FileSystem?.FileMove(_sourcePath, _destinationPath) != null)
        {
            return ApplicationState.Instance.FileSystem.FileMove(_sourcePath, _destinationPath);
        }

        return "File system not connected.";
    }
}
