using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NoHtml.Web
{
    public class FileSystem : IFileSystem
    {
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
    }
}
