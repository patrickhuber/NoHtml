﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NoHtml.Web
{
    public interface IHttpResponse
    {
        Stream OutputStream { get; }
    }
}
