using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NoHtml.Tests.Unit
{
    /// <summary>
    /// Summary description for CachedDocumentModelTests
    /// </summary>
    [TestClass]
    public class CachedDocumentModelTests
    {
        public CachedDocumentModelTests()
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

        private Document[] _documentArray;

        [TestInitialize]
        public void Initialize_CachedDocumentModelTests()
        {
            _documentArray = new[]
            { 
                new Document{ Path = @"\documents\home", Content = "this is the home page."},
                new Document{ Path = @"\documents\home\about", Content = "this is the other page with about info"},
                new Document{ Path = @"\documents\home\index", Content = "this is the index"},
                new Document{ Path = @"\documents\", Content = "this is the root document"},
            };
        }

        [TestMethod]
        public void Test_CachedDocumentModel_Constructor()
        {
            
            var cachedDocumentModel = new CachedDocumentModel(_documentArray);
            var documentHome = cachedDocumentModel.FirstOrDefault(x => x.Path == @"\documents\home");
            Assert.IsNotNull(documentHome);
            Assert.AreEqual(@"\documents\home", documentHome.Path);
        }

        [TestMethod]
        public void Test_CachedDocumentModel_Remove_Array_Modifications_Do_Not_Affect_Cache()
        {
            var cachedCoumentModel = new CachedDocumentModel(_documentArray);
            _documentArray = _documentArray.Where((d, i) => i < 3).ToArray();
            Assert.AreNotEqual(cachedCoumentModel.Count(), _documentArray.Count());
        }
    }
}
