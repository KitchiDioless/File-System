namespace FileSystemApp.FileSystems.FileSystemStates;

public class LocalFileSystemStateDisconnected : IFileSystemState
{
    public IFileSystem FileSystem { get; private set; }

    public LocalFileSystemStateDisconnected(IFileSystem fileSystem)
    {
        FileSystem = fileSystem;
    }

    public string Connect()
    {
        FileSystem.ChangeState(new LocalFileSystemStateConnected(FileSystem));

        return "File system has been connected";
    }

    public string Disconnect()
    {
        return "File system was disconnected";
    }

    public string FileCopy(string sourcePath, string destinationPath)
    {
        return "Connect the file system first";
    }

    public string FileDelete(string path)
    {
        return "Connect the file system first";
    }

    public string FileMove(string sourcePath, string destinationPath)
    {
        return "Connect the file system first";
    }

    public string FileRename(string path, string name)
    {
        return "Connect the file system first";
    }

    public string FileShow(string path, string mode)
    {
        return "Connect the file system first";
    }

    public string TreeGoto(string path)
    {
        return "Connect the file system first";
    }

    public string TreeList(string path, int depth, string filePrefix, string folderPrefix, string indent)
    {
        return "Connect the file system first";
    }
}
