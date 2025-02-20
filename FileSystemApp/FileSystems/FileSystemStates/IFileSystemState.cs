namespace FileSystemApp.FileSystems.FileSystemStates;

public interface IFileSystemState
{
    IFileSystem FileSystem { get; }

    string Connect();

    string Disconnect();

    string TreeGoto(string path);

    string TreeList(string path, int depth, string filePrefix, string folderPrefix, string indent);

    string FileShow(string path, string mode);

    string FileMove(string sourcePath, string destinationPath);

    string FileCopy(string sourcePath, string destinationPath);

    string FileDelete(string path);

    string FileRename(string path, string name);
}
