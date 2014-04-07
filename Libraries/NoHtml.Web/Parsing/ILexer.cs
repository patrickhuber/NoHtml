using System.Collections.Generic;

namespace NoHtml.Web.Parsing
{
    public interface ILexer
    {
        IEnumerable<Token> Tokenize(string input);
        void AddTokenDefinition(TokenDefinition tokenDefinition);
    }
}
