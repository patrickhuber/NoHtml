using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoHtml.Web.Parsing
{
    public interface ILexerFactory
    {
        ILexer CreateLexer();
    }
}
