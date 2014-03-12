using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace NoHtml.Web
{
    public class HttpServerUtilityAdapter : IHttpServerUtility
    {
        private HttpServerUtility httpServerUtility;

        public HttpServerUtilityAdapter(HttpServerUtility httpServerUtility)
        {
            this.httpServerUtility = httpServerUtility;
        }

        public string MapPath(string path)
        {
            return httpServerUtility.MapPath(path);
        }
    }
}
