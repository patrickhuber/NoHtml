using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace NoHtml.Web.Tests.Integration
{
    [TestClass]
    public class FileSystemTests
    {
        private const string OpenReadFile = "OpenRead.dat";
        private const string OpenReadFilePath = "FileSystem\\" + OpenReadFile;
        private const string FileSystemOpenReadReadsFileTarget = "FileSystem_OpenRead_Reads_File";
        private const string FileSystemOpenReadReadsFileTestPath = FileSystemOpenReadReadsFileTarget + "\\" + OpenReadFile;

        [TestMethod]
        [DeploymentItem(OpenReadFilePath, FileSystemOpenReadReadsFileTarget)]
        public void FileSystem_OpenRead_Reads_File()
        {
            IFileSystem fileSystem = new FileSystem();
            using (var stream = fileSystem.OpenRead(FileSystemOpenReadReadsFileTestPath))
            {
                using(var streamReader = new StreamReader(stream))
                {
                    var actual = streamReader.ReadToEnd();
                    const string expected = "OpenRead";
                    Assert.AreEqual(expected, actual);
                }
            }
        }

        private const string ExistsFile = "FileExists.dat";
        private const string ExistsFilePath = "FileSystem\\" + ExistsFile;
        private const string FileSystemFileExistsFindsFileTarget = "FileSystem_FileExists_Finds_File";
        private const string FileSystemFileExistsFildsFileTestPath = FileSystemFileExistsFindsFileTarget + "\\" + ExistsFile;

        [TestMethod]
        [DeploymentItem(ExistsFilePath, FileSystemFileExistsFindsFileTarget)]
        public void FileSystem_FileExists_Finds_File()
        {
            IFileSystem fileSystem = new FileSystem();
            var result = fileSystem.FileExists(FileSystemFileExistsFildsFileTestPath);
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
        public void FileSystem_DirectoryExists_Finds_Directory()
        {
            IFileSystem fileSystem = new FileSystem();
            var result = fileSystem.DirectoryExists(FileSystemDirectoryExistsFindsDirectoryTarget);
            Assert.IsTrue(result);
        }
    }
}
