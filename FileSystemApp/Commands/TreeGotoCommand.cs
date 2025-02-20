using FileSystemApp.ApplicationStates;

namespace FileSystemApp.Commands;

public class TreeGotoCommand : ICommand
{
    private readonly string _path;

    public TreeGotoCommand(string path)
    {
        _path = path;
    }

    public string Execute()
    {
        if (ApplicationState.Instance.FileSystem?.TreeGoto(_path) != null)
        {
            return ApplicationState.Instance.FileSystem.TreeGoto(_path);
        }

        return "File system not connected.";
    }
}
