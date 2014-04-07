using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoHtml.Web.Parsing
{
    public class Lexer : ILexer
    {
        private const char Null = '\0';
        private readonly IList<TokenDefinition> tokenDefinitions;

        public Lexer()
        {
            tokenDefinitions = new List<TokenDefinition>();
        }

        public IEnumerable<Token> Tokenize(string input)
        {
            var startIndex = 0;
            var i = 0;
            for (; i < input.Length; i++)
            {
                var lookAhead = i < input.Length - 1 
                    ? input[i + 1] 
                    : Null;

                var substringBuilder = new StringBuilder(input.Substring(startIndex, i - startIndex + 1));
                var matches = tokenDefinitions
                    .Where(x => x.IsMatch(substringBuilder.ToString()))
                    .ToArray();

                if (matches.Length == 0)
                    throw new Exception(
                        string.Format("Invalid token found at position {0}", startIndex));

                var tokenData = substringBuilder.ToString();
                substringBuilder.Append(lookAhead);

                var anyLookaheadMatches = tokenDefinitions
                    .Any(x => x.IsMatch(substringBuilder.ToString()));

                if (anyLookaheadMatches) 
                    continue;

                var tokenDefinition = matches.First();
                var token = new Token
                    {
                        Type = tokenDefinition.TokenType,
                        Position = startIndex,
                        Data = tokenData
                    };
                startIndex = i + 1;
                yield return token;
            }

            if (i != input.Length)
                throw new Exception("Unexpected end of input reached.");
        }

        public void AddTokenDefinition(TokenDefinition tokenDefinition)
        {
            this.tokenDefinitions.Add(tokenDefinition);
        }
    }
}
