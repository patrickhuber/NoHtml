using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace NoHtml.Web
{
    public class HttpResponseAdapter : IHttpResponse
    {
        private HttpResponse response;

        public HttpResponseAdapter(HttpResponse response)
        {
            this.response = response;
        }

        public System.IO.Stream OutputStream
        {
            get { return response.OutputStream; }
        }
    }
}
