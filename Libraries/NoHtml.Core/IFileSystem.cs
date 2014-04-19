using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NoHtml
{
    public interface IFileSystem
    {
        Stream OpenRead(string path);
        bool DirectoryExists(string path);
        bool FileExists(string path);
        IEnumerable<string> EnumerateDirectories(string path);
        IEnumerable<string> EnumerateDirectories(string path, string searchPattern);
        IEnumerable<string> EnumerateDirectoriesRecursive(string path);
        IEnumerable<string> EnumerateDirectoriesRecursive(string path, string searchPattern);
        IEnumerable<string> EnumerateFiles(string path);
        IEnumerable<string> EnumerateFiles(string path, string searchPattern);        
    }
}
