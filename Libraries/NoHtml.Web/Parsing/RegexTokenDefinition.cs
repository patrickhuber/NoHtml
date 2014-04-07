using System.Text.RegularExpressions;

namespace NoHtml.Web.Parsing
{
    public class RegexTokenDefinition : TokenDefinition
    {
        private Regex regex;

        public RegexTokenDefinition(string tokenType, string pattern)
            : base(tokenType)
        {
            var exactCapture = string.Format("^{0}$", pattern);
            regex = new Regex(exactCapture);
        }

        public override bool IsMatch(string input)
        {
            return regex.IsMatch(input);
        }
    }
}
