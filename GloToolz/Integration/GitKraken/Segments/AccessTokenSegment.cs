using System;
using Newtonsoft.Json;

namespace GloToolz.Integration.GitKraken.Segments
{
    internal sealed class AccessTokenSegment
    {
        public AccessTokenSegment(string grantType, string clientID, string clientSecret, string code)
        {
            GrantType = grantType ?? throw new ArgumentNullException(nameof(grantType));
            ClientID = clientID ?? throw new ArgumentNullException(nameof(clientID));
            ClientSecret = clientSecret ?? throw new ArgumentNullException(nameof(clientSecret));
            Code = code ?? throw new ArgumentNullException(nameof(code));
        }

        [JsonProperty(PropertyName = "grant_type")]
        public string GrantType { get; }

        [JsonProperty(PropertyName = "client_id")]
        public string ClientID { get; }

        [JsonProperty(PropertyName = "client_secret")]
        public string ClientSecret { get; }

        [JsonProperty(PropertyName = "code")]
        public string Code { get; }
    }
}