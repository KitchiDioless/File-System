using FileSystemApp.FileSystems.FileSystemStates;

namespace FileSystemApp.FileSystems;

public interface IFileSystem
{
    string CurrentPath { get; set; }

    IFileSystemState State { get; }

    void ChangeState(IFileSystemState state);

    string Connect();

    string Disconnect();

    string TreeGoto(string path);

    string TreeList(int depth, string filePrefix, string folderPrefix, string indent);

    string FileShow(string path, string mode);

    string FileMove(string sourcePath, string destinationPath);

    string FileCopy(string sourcePath, string destinationPath);

    string FileDelete(string path);

    string FileRename(string path, string name);
}
