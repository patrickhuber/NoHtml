using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace NoHtml.Web.Tests.Integration
{
    /// <summary>
    /// Summary description for MarkdownHttpHandlerTests
    /// </summary>
    [TestClass]
    public class MarkdownHttpHandlerTests
    {
        public MarkdownHttpHandlerTests()
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
        public void MarkdownHttpHandler_Renders_H1()
        {
            var mockHttpRequest = new Mock<IHttpRequest>();
            mockHttpRequest
                .SetupGet(x => x.FilePath)
                .Returns(string.Empty);
            var mockHttpContext = new Mock<IHttpContext>();
            mockHttpContext
                .SetupGet(x => x.Request)
                .Returns(()=>mockHttpRequest.Object);
        }
    }
}
