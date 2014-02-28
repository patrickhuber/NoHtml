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
        private IFileSystem fileSystem;

        public MarkdownHandler(IFileSystem fileSystem)
        {
            this.fileSystem = fileSystem;
        }
        
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {            
        }

        public void ProcessRequest(IHttpContext context)
        {
            var fileStream = fileSystem.OpenRead(context.Request.FilePath);
            using (var streamReader = new StreamReader(fileStream))
            {
                MarkdownSharp.Markdown md = new Markdown();
                var fileText = streamReader.ReadToEnd();
                var responseText = md.Transform(fileText);
            }        
        }
    }
}
