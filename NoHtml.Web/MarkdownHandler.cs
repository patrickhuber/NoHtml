using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarkdownSharp;
using System.Web;
using System.IO;

namespace NoHtml.Web
{
    public class MarkdownHandler : IHttpHandler
    {
        public MarkdownHandler(IFileSystem)
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {            
        }

        public void ProcessRequest(IHttpContext context)
        { }
    }
}
