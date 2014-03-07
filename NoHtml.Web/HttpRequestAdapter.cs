using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace NoHtml.Web
{
    public class HttpRequestAdapter : IHttpRequest
    {
        private HttpRequest request;

        public HttpRequestAdapter(HttpRequest request)
        {
            this.request = request;
        }

        public string FilePath
        {
            get
            {
                return request.FilePath;
            }
        }        
    }
}
