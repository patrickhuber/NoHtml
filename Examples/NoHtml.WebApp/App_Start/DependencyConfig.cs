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
            DependencyResolver.SetResolver(resolver);
        }
    }
}