using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NoHtml.Web.Parsing;

namespace NoHtml.Web.Tests.Unit.Parsing
{
    /// <summary>
    /// Summary description for MarkdownLexerTests
    /// </summary>
    [TestClass]
    public class MarkdownLexerTests
    {
        public MarkdownLexerTests()
        {
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
        

        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion
        
        private static ILexerFactory lexerFactory;
        private ILexer lexer;

        [ClassInitialize()]
        public static void MarkdownLexerTests_ClassInitialize(TestContext testContext)
        {
            lexerFactory = new MarkdownLexerFactory();
        }

        [TestInitialize()]
        public void Initialize_MarkdownLexerTests()
        {
            lexer = lexerFactory.CreateLexer();
        }

        [TestMethod]
        public void Test_Lexer_Recognizes_Header_Text_And_EndOfLine()
        {
            var tokens = lexer.Tokenize("# This is a H1 \r\n## This is a H2\r\n### This is a H3");
            var expected = new[]
                {
                    TokenDescriptor.HashHeading.Name,   // #
                    TokenDescriptor.WhiteSpace.Name,    // 
                    TokenDescriptor.Word.Name,          // This
                    TokenDescriptor.WhiteSpace.Name,    // 
                    TokenDescriptor.Word.Name,          // is
                    TokenDescriptor.WhiteSpace.Name,    // 
                    TokenDescriptor.Word.Name,          // a
                    TokenDescriptor.WhiteSpace.Name,    // 
                    TokenDescriptor.Word.Name,          // H1
                    TokenDescriptor.WhiteSpace.Name,    // 
                    TokenDescriptor.NewLine.Name,       // <eol>
                    TokenDescriptor.HashHeading.Name,   // ##
                    TokenDescriptor.WhiteSpace.Name,    // 
                };
            int i = -1;
            foreach (var token in tokens)
            {
                i++;
                if(i < expected.Length)
                    Assert.AreEqual(expected[i], token.Type);
            }
        }
    }
}
