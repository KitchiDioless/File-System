using FileSystemApp.FileSystems.FileSystemStates;

namespace FileSystemApp.FileSystems;

public class LocalFileSystem : IFileSystem
{
    public string CurrentPath { get; set; }

    public IFileSystemState State { get; private set; }

    public LocalFileSystem(string currentPath)
    {
        CurrentPath = currentPath;

        State = new LocalFileSystemStateDisconnected(this);
    }

    public void ChangeState(IFileSystemState state)
    {
        State = state;
    }

    public string Connect()
    {
        return State.Connect();
    }

    public string Disconnect()
    {
        return State.Disconnect();
    }

    public string TreeGoto(string path)
    {
        return State.TreeGoto(path);
    }

    public string TreeList(int depth, string filePrefix, string folderPrefix, string indent)
    {
        return State.TreeList(CurrentPath, depth, filePrefix, folderPrefix, indent);
    }

    public string FileShow(string path, string mode)
    {
        return State.FileShow(path, mode);
    }

    public string FileMove(string sourcePath, string destinationPath)
    {
        return State.FileMove(sourcePath, destinationPath);
    }

    public string FileCopy(string sourcePath, string destinationPath)
    {
        return State.FileCopy(sourcePath, destinationPath);
    }

    public string FileDelete(string path)
    {
        return State.FileDelete(path);
    }

    public string FileRename(string path, string name)
    {
        return State.FileRename(path, name);
    }
}
