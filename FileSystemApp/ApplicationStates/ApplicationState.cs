using FileSystemApp.FileSystems;
using System.IO;

namespace FileSystemApp.ApplicationStates;

public class ApplicationState
{
    private static ApplicationState _instance;

    public string ConnectionPath { get; private set; }

    public IFileSystem FileSystem { get; private set; }

    private ApplicationState(string initialPath)
    {
        ConnectionPath = initialPath;
    }

    public static ApplicationState Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ApplicationState(Directory.GetCurrentDirectory());
            }

            return _instance;
        }
    }

    public void ChangeConnectionPath(string newPath)
    {
        ConnectionPath = newPath;
    }

    public void InitializeFileSystem(IFileSystem fileSystem)
    {
        FileSystem = fileSystem;
    }
}
