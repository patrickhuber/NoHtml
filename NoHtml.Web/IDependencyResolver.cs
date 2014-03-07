using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoHtml.Web
{
    public interface IDependencyResolver
    {
        T GetService<T>();
        T GetService<T>(string name);
    }
}
