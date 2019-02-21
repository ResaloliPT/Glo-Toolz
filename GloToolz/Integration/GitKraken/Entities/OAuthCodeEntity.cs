using GloToolz.Integration.GitKraken.Entities.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GloToolz.Integration.GitKraken.Entities
{
    internal sealed class OAuthCodeEntity : GKEntity<OAuthCodeEntity>
    {
        private OAuthCodeEntity(string code, string state)
        {
            Code = code ?? throw new ArgumentNullException(nameof(code));
            State = state ?? throw new ArgumentNullException(nameof(state));
        }

        public string Code { get; }

        public string State { get; }

        new public static OAuthCodeEntity CreateEntity(HttpListenerRequest listenerRequest)
        {
            listenerRequest = listenerRequest ?? throw new ArgumentNullException(nameof(listenerRequest));
            return new OAuthCodeEntity(listenerRequest.QueryString["code"], listenerRequest.QueryString["state"]);
        }
    }
}