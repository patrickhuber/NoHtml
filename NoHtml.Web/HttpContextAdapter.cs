using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace NoHtml.Web
{
    public class HttpContextAdapter : IHttpContext
    {
        public HttpContext httpContext;
        
        public HttpContextAdapter(HttpContext httpContext)
        {
            this.httpContext = httpContext;
        }

        public IHttpRequest Request
        {
            get
            {
                return new HttpRequestAdapter(httpContext.Request);
            }
        }

        public IHttpResponse Response
        {
            get
            {
                return new HttpResponseAdapter(httpContext.Response);
            }
        }
    }
}
