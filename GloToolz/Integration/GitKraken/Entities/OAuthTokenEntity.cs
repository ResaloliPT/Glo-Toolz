using GloToolz.Integration.GitKraken.Entities.API;
using Newtonsoft.Json;
using System;

namespace GloToolz.Integration.GitKraken.Entities
{
    internal sealed class OAuthTokenEntity : GKEntity<OAuthTokenEntity>
    {
        public OAuthTokenEntity(string accessToken, string tokenType)
        {
            AccessToken = accessToken ?? throw new ArgumentNullException(nameof(accessToken));
            TokenType = tokenType ?? throw new ArgumentNullException(nameof(tokenType));
        }

        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; }

        [JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; }
    }
}