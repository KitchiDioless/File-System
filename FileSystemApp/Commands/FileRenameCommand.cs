using FileSystemApp.ApplicationStates;

namespace FileSystemApp.Commands;

public class FileRenameCommand : ICommand
{
    private readonly string _path;

    private readonly string _name;

    public FileRenameCommand(string path, string name)
    {
        _path = path;
        _name = name;
    }

    public string Execute()
    {
        if (ApplicationState.Instance.FileSystem?.FileRename(_path, _name) != null)
        {
            return ApplicationState.Instance.FileSystem.FileRename(_path, _name);
        }

        return "File system not connected.";
    }
}
