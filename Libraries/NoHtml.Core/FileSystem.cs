using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NoHtml
{
    public class FileSystem : IFileSystem
    {
        public static readonly string DefaultSearchPattern = "*.*";

        public System.IO.Stream OpenRead(string path)
        {
            return File.OpenRead(path);
        }
        
        public bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        public bool FileExists(string path)
        {
            return File.Exists(path);
        }

        public IEnumerable<string> EnumerateDirectories(string path)
        {
            return Directory.EnumerateDirectories(path);
        }

        public IEnumerable<string> EnumerateDirectories(string path, string searchPattern)
        {
            return Directory.EnumerateDirectories(path, searchPattern, SearchOption.TopDirectoryOnly);
        }

        public IEnumerable<string> EnumerateDirectoriesRecursive(string path)
        {
            return Directory.EnumerateDirectories(path, DefaultSearchPattern, SearchOption.AllDirectories);
        }

        public IEnumerable<string> EnumerateDirectoriesRecursive(string path, string searchPattern)
        {
            return Directory.EnumerateDirectories(path, searchPattern, SearchOption.AllDirectories);
        }

        public IEnumerable<string> EnumerateFiles(string path)
        {
            return Directory.EnumerateFiles(path);
        }

        public IEnumerable<string> EnumerateFiles(string path, string searchPattern)
        {
            return Directory.EnumerateFiles(path, searchPattern);
        }
    }
}
