using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoHtml.Web
{
    public interface IHttpRequest
    {
        string FilePath { get; }
    }
}
