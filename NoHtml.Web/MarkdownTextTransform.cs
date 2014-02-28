using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoHtml.Web
{
    public class MarkdownTextTransform : ITextTransform
    {
        private MarkdownSharp.Markdown markdown;
        public MarkdownTextTransform(MarkdownSharp.Markdown markdown)
        {
            this.markdown = markdown;
        }

        public string Transform(string input)
        {
            return markdown.Transform(input);
        }
    }
}
