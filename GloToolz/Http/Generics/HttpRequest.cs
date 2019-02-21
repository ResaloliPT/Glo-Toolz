using GloToolz.Integration.GitKraken.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;

namespace GloToolz.Http.Generics
{
    internal class HttpRequest<TContent> : HttpRequest
    {
        public readonly string RequestURL;

        public readonly HttpMethod Method;

        public readonly TContent Content;

        public readonly NameValueCollection QueryString;

        public HttpRequest(string requestURL, HttpMethod method, TContent content, NameValueCollection queryString, OAuthTokenEntity token)
        {
            RequestURL = requestURL ?? throw new ArgumentNullException(nameof(requestURL));
            Method = method;
            Content = content;
            QueryString = queryString == null ? new NameValueCollection() : queryString;
        }

        public override HttpRequestMessage GetRequestMessage()
        {
            var request = new HttpRequestMessage(Method, RequestURL);

            if (Content != null)
            {
                request.Content = new StringContent(
                    JsonConvert.SerializeObject(Content),
                    Encoding.UTF8,
                    "application/json"
                );
            }

            if (QueryString.Count > 0)
            {
                var queryString = new StringBuilder();
                queryString.Append("?");

                foreach (var query in QueryString.AllKeys)
                {
                    queryString.Append(string.Format("{0}={1}", new object[] { query, QueryString.Get(query)}));
                }

                request.RequestUri = new Uri(request.RequestUri.OriginalString + queryString.ToString()); 
            }

            return request;
        }
    }
}