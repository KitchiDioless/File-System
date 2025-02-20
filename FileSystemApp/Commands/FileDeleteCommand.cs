using FileSystemApp.ApplicationStates;

namespace FileSystemApp.Commands;

public class FileDeleteCommand : ICommand
{
    private readonly string _path;

    public FileDeleteCommand(string path)
    {
        _path = path;
    }

    public string Execute()
    {
        if (ApplicationState.Instance.FileSystem?.FileDelete(_path) != null)
        {
            return ApplicationState.Instance.FileSystem.FileDelete(_path);
        }

        return "File system not connected.";
    }
}
