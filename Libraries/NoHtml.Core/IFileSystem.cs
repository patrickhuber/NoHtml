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
    }
}
