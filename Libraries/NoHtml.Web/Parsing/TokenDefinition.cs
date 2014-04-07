namespace NoHtml.Web.Parsing
{
    

    public abstract class TokenDefinition : ITokenDefinition
    {
        public string TokenType { get; private set; }
        public abstract bool IsMatch(string input);

        protected TokenDefinition(string tokenType)
        {
            TokenType = tokenType;
        }
    }
}
