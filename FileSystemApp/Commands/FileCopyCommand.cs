using FileSystemApp.ApplicationStates;

namespace FileSystemApp.Commands;

public class FileCopyCommand : ICommand
{
    private readonly string _sourcePath;

    private readonly string _destinationPath;

    public FileCopyCommand(string sourcePath, string destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public string Execute()
    {
        if (ApplicationState.Instance.FileSystem?.FileCopy(_sourcePath, _destinationPath) != null)
        {
            ApplicationState.Instance.FileSystem?.FileCopy(_sourcePath, _destinationPath);
        }

        return "File system not connected.";
    }
}
