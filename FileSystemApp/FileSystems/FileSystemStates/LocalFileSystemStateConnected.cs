using FileSystemApp.Utils;
using System;
using System.IO;

namespace FileSystemApp.FileSystems.FileSystemStates;

public class LocalFileSystemStateConnected : IFileSystemState
{
    public IFileSystem FileSystem { get; private set; }

    public LocalFileSystemStateConnected(IFileSystem fileSystem)
    {
        FileSystem = fileSystem;
    }

    public string Connect()
    {
        return "File system was connected";
    }

    public string Disconnect()
    {
        FileSystem.ChangeState(new LocalFileSystemStateDisconnected(FileSystem));

        return "File system has been disconnected";
    }

    public string FileCopy(string sourcePath, string destinationPath)
    {
        try
        {
            sourcePath = GetFullPath(sourcePath);
            destinationPath = GetFullPath(destinationPath);

            if (!File.Exists(sourcePath))
            {
                return $"Source file '{sourcePath}' does not exist.";
            }

            string? destDirectory = Path.GetDirectoryName(destinationPath);
            if (!Directory.Exists(destDirectory) && destDirectory != null)
            {
                Directory.CreateDirectory(destDirectory);
            }

            File.Copy(sourcePath, destinationPath, true);

            return $"File '{sourcePath}' has been copied to '{destinationPath}'.";
        }
        catch (Exception ex)
        {
            return $"Error copying file: {ex.Message}";
        }
    }

    public string FileDelete(string path)
    {
        try
        {
            path = GetFullPath(path);

            if (!File.Exists(path))
            {
                return $"File '{path}' does not exist.";
            }

            File.Delete(path);

            return $"File '{path}' has been deleted.";
        }
        catch (Exception ex)
        {
            return $"Error deleting file: {ex.Message}";
        }
    }

    public string FileMove(string sourcePath, string destinationPath)
    {
        try
        {
            sourcePath = GetFullPath(sourcePath);
            destinationPath = GetFullPath(destinationPath);

            if (!File.Exists(sourcePath))
            {
                return $"Source file '{sourcePath}' does not exist.";
            }

            string? destDirectory = Path.GetDirectoryName(destinationPath);
            if (!Directory.Exists(destDirectory) && destDirectory != null)
            {
                Directory.CreateDirectory(destDirectory);
            }

            File.Move(sourcePath, destinationPath);

            return $"File '{sourcePath}' has been moved to '{destinationPath}'.";
        }
        catch (Exception ex)
        {
            return $"Error moving file: {ex.Message}";
        }
    }

    public string FileRename(string path, string name)
    {
        try
        {
            path = GetFullPath(path);

            if (!File.Exists(path))
            {
                return $"File '{path}' does not exist.";
            }

            string? directory = Path.GetDirectoryName(path);
            string newPath = Path.Combine(directory ?? string.Empty, name);

            File.Move(path, newPath);

            return $"File '{path}' has been renamed to '{name}'.";
        }
        catch (Exception ex)
        {
            return $"Error renaming file: {ex.Message}";
        }
    }

    public string FileShow(string path, string mode)
    {
        try
        {
            path = GetFullPath(path);

            if (!File.Exists(path))
            {
                return $"File '{path}' does not exist.";
            }

            string content = File.ReadAllText(path);

            return content;
        }
        catch (Exception ex)
        {
            return $"Error reading file: {ex.Message}";
        }
    }

    public string TreeGoto(string path)
    {
        FileSystem.CurrentPath = GetFullPath(path);

        return "Current path has been changed";
    }

    public string TreeList(string path, int depth, string filePrefix, string folderPrefix, string indent)
    {
        var treeGenerator = new TreeGenerator(filePrefix, folderPrefix, indent, depth);

        return treeGenerator.Generate(path);
    }

    private bool IsAbsolutePath(string path)
    {
        return Path.IsPathRooted(path);
    }

    private string GetFullPath(string path)
    {
        if (IsAbsolutePath(path))
        {
            return path;
        }

        return Path.Combine(FileSystem.CurrentPath, path);
    }
}
