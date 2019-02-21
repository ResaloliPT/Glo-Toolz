using System;

namespace GloToolz.Exceptions
{
    public sealed class OAuthException : Exception
    {
        public OAuthException(string message) : base(message)
        { }

        public OAuthException() : base("Erro in OAuth")
        { }
    }
}