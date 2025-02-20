using FileSystemApp.ApplicationStates;

namespace FileSystemApp.Commands;

public class FileShowCommand : ICommand
{
    private readonly string _path;

    private readonly string _mode;

    public FileShowCommand(string path, string mode)
    {
        _path = path;
        _mode = mode;
    }

    public string Execute()
    {
        if (ApplicationState.Instance.FileSystem?.FileShow(_path, _mode) != null)
        {
            return ApplicationState.Instance.FileSystem.FileShow(_path, _mode);
        }

        return "File system not connected.";
    }
}
