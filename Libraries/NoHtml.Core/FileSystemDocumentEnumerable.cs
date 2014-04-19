using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NoHtml
{
    public class FileSystemDocumentEnumerable : IEnumerable<Document>
    {
        private IFileSystem _fileSystem;
        private string _path;
        private string _searchPattern;

        public FileSystemDocumentEnumerable(IFileSystem fileSystem, string path, string searchPattern)
        {
            _fileSystem = fileSystem;
            _path = path;
            _searchPattern = searchPattern;
        }

        public IEnumerator<Document> GetEnumerator()
        {
            foreach (var document in EnumerateDocuments(_path, _searchPattern))
            {
                yield return document;
            }

            foreach (var directory in _fileSystem.EnumerateDirectoriesRecursive(_path, _searchPattern))
            {
                foreach (var document in EnumerateDocuments(directory, _searchPattern))
                {
                    yield return document;
                }
            }
        }

        private IEnumerable<Document> EnumerateDocuments(string path, string pattern)
        {
            foreach (var file in _fileSystem.EnumerateFiles(_path, _searchPattern))
            {
                using (var streamReader = new StreamReader(_fileSystem.OpenRead(file)))
                {
                    yield return new Document
                    {
                        Content = streamReader.ReadToEnd(),
                        Path = file
                    };
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
