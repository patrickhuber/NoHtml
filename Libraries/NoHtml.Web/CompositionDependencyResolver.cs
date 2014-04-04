using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NoHtml.Web
{
    public class CompositionDependencyResolver : IDependencyResolver
    {
        private CompositionContainer container;

        

        public CompositionDependencyResolver(CompositionContainer container)
        {
            if(container == null)
                throw new ArgumentNullException("container", "the container object is null.");
            this.container = container;
        }

        public T GetService<T>()
        {
            return container.GetExport<T>().Value;
        }

        public T GetService<T>(string name)
        {
            return container.GetExport<T>(name).Value;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            var innerImportDefinition = new TypeImportDefinition(serviceType);
            var matching = container.GetExports(innerImportDefinition);
            return matching.Select(match => match.Value);
        }

        public object GetService(Type serviceType)
        {
            var matching = container.GetExports(serviceType, null, null);
            return matching
                .Select(match => match.Value)
                .FirstOrDefault();
        }

        public void Register<T>(T value)
        {
            container.ComposeExportedValue<T>(value);
        }

        public void Register<T>(T value, string name)
        {
            container.ComposeExportedValue<T>(name, value);
        }
    }
}
