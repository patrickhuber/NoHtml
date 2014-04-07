using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoHtml.Web.Parsing
{
    public class MarkdownLexerFactory : ILexerFactory
    {
        public ILexer CreateLexer()
        {
            var lexer = new Lexer();
            lexer.AddTokenDefinition(new RegexTokenDefinition(TokenDescriptor.NewLine.Name, @"(\n|\r|\r\n)"));
            lexer.AddTokenDefinition(new RegexTokenDefinition(TokenDescriptor.HashHeading.Name, @"#{1,6}"));
            lexer.AddTokenDefinition(new RegexTokenDefinition(TokenDescriptor.Number.Name, @"\d+"));
            lexer.AddTokenDefinition(new RegexTokenDefinition(TokenDescriptor.Asterix.Name, @"[*]"));
            lexer.AddTokenDefinition(new RegexTokenDefinition(TokenDescriptor.Period.Name, @"[.]"));
            lexer.AddTokenDefinition(new RegexTokenDefinition(TokenDescriptor.Word.Name, @"\w+"));
            lexer.AddTokenDefinition(new RegexTokenDefinition(TokenDescriptor.WhiteSpace.Name, @"[ \t]"));
            return lexer;
        }
    }
}
