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
        private readonly IFileSystem fileSystem;
        private readonly ITextTransform textTransform;

        public MarkdownHandler()
            : this(
                DependencyResolver.Instance.GetService<IFileSystem>(), 
                DependencyResolver.Instance.GetService<ITextTransform>("markdown"))
        { }

        public MarkdownHandler(IFileSystem fileSystem, ITextTransform textTransform)
        {
            this.fileSystem = fileSystem;
            this.textTransform = textTransform;
        }
        
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            ProcessRequest(new HttpContextAdapter(context));
        }

        public void ProcessRequest(IHttpContext context)
        {
            var fileStream = fileSystem.OpenRead(context.Request.FilePath);
            using (var streamReader = new StreamReader(fileStream))
            {
                var fileText = streamReader.ReadToEnd();
                var responseText = textTransform.Transform(fileText);
                var streamWriter = new StreamWriter(context.Response.OutputStream);
                streamWriter.Write(responseText);
                streamWriter.Flush();
            }        
        }
    }
}
