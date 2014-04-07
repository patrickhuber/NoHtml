using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoHtml.Web.Parsing
{
    public class TokenDescriptor
    {
        public string Name { get; set; }
        public static readonly TokenDescriptor NewLine = new TokenDescriptor {  Name = "NEWLINE"};
        public static readonly TokenDescriptor HashHeading = new TokenDescriptor {Name = "HASH_HEADING"};
        public static readonly TokenDescriptor Number = new TokenDescriptor { Name = "NUMBER"};
        public static readonly TokenDescriptor Asterix = new TokenDescriptor {Name = "ASTERIX"};
        public static readonly TokenDescriptor Period = new TokenDescriptor {  Name = "PERIOD"};
        public static readonly TokenDescriptor Word = new TokenDescriptor { Name = "WORD" };
        public static readonly TokenDescriptor WhiteSpace = new TokenDescriptor {Name = "WHITESPACE"};
    }
}