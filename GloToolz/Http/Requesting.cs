using GloToolz.Integration.GitKraken.Entities;
using System.Net.Http;
using System.Threading.Tasks;

namespace GloToolz.Http
{
    internal static class Requesting
    {
        public static async Task<TGKEntity> MakeRequest<TGKEntity>(HttpRequest message) where TGKEntity : GKEntity
        {
            HttpClient client = new HttpClient();

            var requestMessage = message.GetRequestMessage();

            HttpResponseMessage response = await client.SendAsync(requestMessage);

            return await response.Content.ReadAsAsync<TGKEntity>();
        }
    }
}