using FileSystemApp.ApplicationStates;
using FileSystemApp.FileSystems;

namespace FileSystemApp.Commands;

public class ConnectCommand : ICommand
{
    private readonly string _path;

    private readonly string _fileSystemMode;

    public ConnectCommand(string path, string fileSystemMode)
    {
        _path = path;
        _fileSystemMode = fileSystemMode;
    }

    public string Execute()
    {
        if (_fileSystemMode == "local")
        {
            ApplicationState.Instance.InitializeFileSystem(new LocalFileSystem(_path));

            ApplicationState.Instance.ChangeConnectionPath(_path);

            if (ApplicationState.Instance.FileSystem?.Connect() != null)
            {
                return ApplicationState.Instance.FileSystem.Connect();
            }
        }

        return "Unknown mode";
    }
}
