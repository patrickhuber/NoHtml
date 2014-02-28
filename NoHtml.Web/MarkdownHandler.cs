using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarkdownSharp;
using System.Web;

namespace NoHtml.Web
{
    public class MarkdownHandler : IHttpHandler
    {
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
