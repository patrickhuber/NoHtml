using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using NoHtml.Web;

namespace NoHtml.Web.Tests.Unit
{
    [TestClass]
    public class FileSystemTests
    {
        [TestMethod]
        [DeploymentItem("OpenRead.dat")]
        public void FileSystem_OpenRead_Reads_File()
        {
            IFileSystem fileSystem = new FileSystem();
            using (var stream = fileSystem.OpenRead("OpenRead.dat"))
            {
                using(var streamReader = new StreamReader(stream))
                {
                    var actual = streamReader.ReadToEnd();
                    const string expected = "OpenRead";
                    Assert.AreEqual(expected, actual);
                }
            }
        }
    }
}
