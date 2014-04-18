using MarkdownSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoHtml.Web.Tests.Integration
{
    [TestClass]
    public class TextTransformTests
    {
        [TestMethod]
        public void TextTransform_Transforms_H1()
        {
            ITextTransform transform = new MarkdownTextTransform(new Markdown());
            var actual = transform.Transform("#hey");
            var expected = "<h1>hey</h1>\n";
            Assert.AreEqual(expected, actual);
        }
    }
}
