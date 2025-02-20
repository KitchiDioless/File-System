using FileSystemApp.ApplicationStates;

namespace FileSystemApp.Commands;

public class TreeListCommand : ICommand
{
    private readonly int _depth;

    private readonly string _filePrefix;

    private readonly string _folderPrefix;

    private readonly string _indent;

    public TreeListCommand(int depth = 1, string filePrefix = "─", string folderPrefix = "├", string indent = " ")
    {
        _depth = depth;
        _filePrefix = filePrefix;
        _folderPrefix = folderPrefix;
        _indent = indent;
    }

    public string Execute()
    {
        if (ApplicationState.Instance.FileSystem?.TreeList(_depth, _filePrefix, _folderPrefix, _indent) != null)
        {
            return ApplicationState.Instance.FileSystem.TreeList(_depth, _filePrefix, _folderPrefix, _indent);
        }

        return "File system not connected.";
    }
}