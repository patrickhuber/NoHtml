using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace NoHtml.Web
{
    public class HttpContextFactory : IHttpContextFactory
    {
        public IHttpContext CreateContext()
        {            
            return new HttpContextAdapter(HttpContext.Current);
        }
    }
}
