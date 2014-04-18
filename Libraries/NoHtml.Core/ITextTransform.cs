using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoHtml
{
    public interface ITextTransform
    {
        string Transform(string input);
    }
}
