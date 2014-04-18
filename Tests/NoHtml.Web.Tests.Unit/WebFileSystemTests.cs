using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.IO;
using NoHtml;

namespace NoHtml.Web.Tests.Unit
{
    /// <summary>
    /// Summary description for WebFileSystemTests
    /// </summary>
    [TestClass]
    public class WebFileSystemTests
    {
        public WebFileSystemTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Test_WebFileSystem_OpenRead_Returns_Mapped_Path()
        {
            var mockFileSystem = new Mock<IFileSystem>();
            var mockHttpContextFactory = new Mock<IHttpContextFactory>();
            var mockHttpContext = new Mock<IHttpContext>();
            var mockHttpServerUtility = new Mock<IHttpServerUtility>();

            mockFileSystem
                .Setup(x => x.OpenRead(It.IsAny<string>()))
                .Returns(new MemoryStream());

            mockHttpServerUtility
                .Setup(x => x.MapPath(It.IsAny<string>()))
                .Returns<string>(x=>x);

            mockHttpContext
                .SetupGet(x => x.Server)
                .Returns(mockHttpServerUtility.Object);

            mockHttpContextFactory
                .Setup(x => x.CreateContext())
                .Returns(mockHttpContext.Object);

            IFileSystem fileSystem = new WebFileSystem(mockFileSystem.Object, mockHttpContextFactory.Object);
            using (var result = fileSystem.OpenRead("abc123"))
            { }
            mockHttpServerUtility.Verify(x=>x.MapPath(It.IsAny<string>()), Times.Once);
        }
    }
}
