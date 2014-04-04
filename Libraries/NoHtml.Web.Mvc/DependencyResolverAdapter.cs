using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoHtml.Web.Mvc
{
    public class DependencyResolverAdapter : System.Web.Mvc.IDependencyResolver
    {
        private readonly IDependencyResolver dependencyResolver;

        public DependencyResolverAdapter(NoHtml.Web.IDependencyResolver dependencyResolver)
        {
            this.dependencyResolver = dependencyResolver;
        }

        public object GetService(Type serviceType)
        {
            return dependencyResolver.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return dependencyResolver.GetServices(serviceType);
        }
    }
}
