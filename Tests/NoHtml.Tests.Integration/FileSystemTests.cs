using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace NoHtml.Web.Tests.Integration
{
    [TestClass]
    public class FileSystemTests
    {
        private static class FS
        {
            public const string Root = "FileSystem";
            public static class OpenRead
            {
                public const string Content = "OpenRead";
                public const string File = "OpenRead.dat";
                public const string Path = Root + @"\" + File;
                public const string Target = "FileSystem_OpenRead_Reads_File";
                public const string TargetPath = Target + @"\" + File;
            }

            public static class FileExists
            {
                public const string File = "FileExists.dat";
                public const string Path = Root + @"\" + File;
                public const string Target = "FileSystem_FileExists_Finds_File";
                public const string TargetPath = Target + @"\" + File;
            }    
            
            public static class Directories
            {
                public const string Root = FS.Root + @"\Directories";
                public const string File = "File.dat";
                public const string FilePath = Root + @"\" + File;
            }
        }

        [TestMethod]
        [DeploymentItem(FS.OpenRead.Path, FS.OpenRead.Target)]
        public void Test_FileSystem_OpenRead_Reads_File()
        {
            IFileSystem fileSystem = new FileSystem();
            using (var stream = fileSystem.OpenRead(FS.OpenRead.TargetPath))
            {
                using(var streamReader = new StreamReader(stream))
                {
                    var actual = streamReader.ReadToEnd();
                    const string expected = FS.OpenRead.Content;
                    Assert.AreEqual(expected, actual);
                }
            }
        }

        [TestMethod]
        [DeploymentItem(FS.FileExists.Path, FS.FileExists.Target)]
        public void Test_FileSystem_FileExists_Finds_File()
        {
            IFileSystem fileSystem = new FileSystem();
            var result = fileSystem.FileExists(FS.FileExists.TargetPath);
            Assert.IsTrue(result);
        }

        private const string NoOpFileDirectory = "FileSystem\\Directories\\";
        private const string NoOpFile = "File.dat";
        private const string NoOpFilePath = NoOpFileDirectory + NoOpFile;
        private const string FileSystemDirectoryExistsFindsDirectoryTarget = "FileSystem_DirectoryExists_Finds_Directory";
        private const string FileSystemDirectoryExistsFindsDirectoryTestPath =
            FileSystemDirectoryExistsFindsDirectoryTarget + "\\" + NoOpFile;


        [TestMethod]
        [DeploymentItem(NoOpFilePath, FileSystemDirectoryExistsFindsDirectoryTarget)]
        public void Test_FileSystem_DirectoryExists_Finds_Directory()
        {
            IFileSystem fileSystem = new FileSystem();
            var result = fileSystem.DirectoryExists(FileSystemDirectoryExistsFindsDirectoryTarget);
            Assert.IsTrue(result);
        }
    }
}
