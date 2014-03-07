using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;

namespace NoHtml.Web
{
    public class CompositionDependencyResolver : IDependencyResolver
    {
        private CompositionContainer container;

        public CompositionDependencyResolver(CompositionContainer container)
        {
            this.container = container;
        }

        public T GetService<T>()
        {
            return this.container.GetExport<T>().Value;
        }

        public T GetService<T>(string name)
        {
            return this.container.GetExport<T>(name).Value;
        }
    }
}
