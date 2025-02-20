using FileSystemApp.ApplicationStates;

namespace FileSystemApp.Commands;

public class DisconnectCommand : ICommand
{
    public string Execute()
    {
        if (ApplicationState.Instance.FileSystem?.Disconnect() != null)
        {
            return ApplicationState.Instance.FileSystem.Disconnect();
        }

        return "File system not connected.";
    }
}
