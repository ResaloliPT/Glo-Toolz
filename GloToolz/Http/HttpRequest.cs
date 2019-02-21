using System.Net.Http;

namespace GloToolz.Http
{
    public abstract class HttpRequest
    {
        public abstract HttpRequestMessage GetRequestMessage();
    }
}