using System;
using System.IO;

namespace FileSystemApp.Utils;

public class TreeGenerator
{
    private readonly string _filePrefix;

    private readonly string _folderPrefix;

    private readonly string _indent;

    private readonly int _maxDepth;

    public TreeGenerator(string filePrefix, string folderPrefix, string indent, int maxDepth)
    {
        _filePrefix = filePrefix;
        _folderPrefix = folderPrefix;
        _indent = indent;
        _maxDepth = maxDepth;
    }

    public string Generate(string path)
    {
        if (!Directory.Exists(path))
        {
            throw new ArgumentException("Указанный путь не существует.", nameof(path));
        }

        return GenerateTree(path, _maxDepth, string.Empty);
    }

    private string GenerateTree(string path, int depth, string currentIndent)
    {
        if (depth < 0 || !Directory.Exists(path))
        {
            return string.Empty;
        }

        var result = new System.Text.StringBuilder();
        string[] entries = Directory.GetFileSystemEntries(path);

        for (int i = 0; i < entries.Length; i++)
        {
            string entry = entries[i];
            bool isLast = i == entries.Length - 1;
            string prefix = isLast ? "└" : _folderPrefix;

            if (Directory.Exists(entry))
            {
                result.AppendLine($"{currentIndent}{prefix} {Path.GetFileName(entry)}");

                if (depth > 1)
                {
                    result.Append(GenerateTree(entry, depth - 1, currentIndent + (isLast ? " " : _indent)));
                }
            }
            else
            {
                result.AppendLine($"{currentIndent}{_filePrefix} {Path.GetFileName(entry)}");
            }
        }

        return result.ToString();
    }
}
