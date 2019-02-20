using GloToolz.Integration.GitKraken.Entities.API;
using System;
using System.Configuration;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GloToolz.Http
{
    internal static class OAuth
    {
        private static string AccessToken;

        public async static Task<bool> Authenticate()
        {
            //Get important info
            string redirect_URL = ConfigurationManager.AppSettings["OAUTH_REDIRECT"];
            string gitkraken_authorize_URL = ConfigurationManager.AppSettings["GITKRAKEN_AUTHORIZE"];
            string clientID = ConfigurationManager.AppSettings["OAUTH_CLIENTID"];
            
            //Generate Random state
            string state = randomB64(32);

            //Start listening http server
            HttpListener httpListener = new HttpListener();
            httpListener.Prefixes.Add(redirect_URL);
            httpListener.Start();

            string request_URL = string.Format("{0}?response_type=code&scope=board:write user:read&state={1}&client_id={2}", new object[] {
                Uri.EscapeDataString(redirect_URL),
                state,
                clientID
            });

            //Start Browser to OAUTH
            System.Diagnostics.Process.Start(request_URL);

            var requestContext = await httpListener.GetContextAsync();

            return false;
        }

        public static T MakeRequest<T>() where T : GKEntity
        {
            return default(T);
        }

        #region Helpers
        public static string randomB64(uint length)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] bytes = new byte[length];
            rng.GetBytes(bytes);
            return removeB64Padding(bytes);
        }

        public static byte[] sha256(string inputStirng)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(inputStirng);
            SHA256Managed sha256 = new SHA256Managed();
            return sha256.ComputeHash(bytes);
        }

        public static string removeB64Padding(byte[] buffer)
        {
            string base64 = Convert.ToBase64String(buffer);

            base64 = base64.Replace("+", "-");
            base64 = base64.Replace("/", "_");
            base64 = base64.Replace("=", "");

            return base64;
        }
        #endregion
    }
}