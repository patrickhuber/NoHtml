using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoHtml.Web.Parsing
{
    public class StringTokenDefinition : TokenDefinition
    {
        private string match;
        private StringComparison stringComparison;

        public StringTokenDefinition(string tokenType, string match)
            : this(tokenType, match, StringComparison.CurrentCulture)
        {
        }

        public StringTokenDefinition(string tokenType, string match, StringComparison stringComparison)
            : base(tokenType)
        {
            this.match = match;
            this.stringComparison = stringComparison;
        }

        public override bool IsMatch(string input)
        {
            return string.Compare(input, match, stringComparison) == 0;
        }
    }
}
