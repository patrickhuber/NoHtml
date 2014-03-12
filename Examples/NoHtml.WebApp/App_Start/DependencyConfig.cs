using NoHtml.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Web;

namespace NoHtml.WebApp
{
    public static class DependencyConfig
    {
        public static void RegisterDependencies()
        {
            var container = new CompositionContainer();            
            var resolver = new CompositionDependencyResolver(container);
            resolver.Register<IHttpContextFactory>(new HttpContextFactory());
            resolver.Register<IFileSystem>(new FileSystem(), "fileSystem");
            resolver.Register<IFileSystem>(new WebFileSystem());
            resolver.Register<ITextTransform>(new MarkdownTextTransform(new MarkdownSharp.Markdown()), "markdown");
            DependencyResolver.SetResolver(resolver);
        }
    }
}