using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Markdown = MarkdownDeep.Markdown;
namespace NoHtml.Web.MarkdownDeep
{
    public class MarkdownDeepTextTransform : ITextTransform
    {
        private Markdown markdown;

        public string Transform(string input)
        {
            return markdown.Transform(input);
        }
    }
}
