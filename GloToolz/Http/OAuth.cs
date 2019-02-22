using GloToolz.Exceptions;
using GloToolz.Http.Generics;
using GloToolz.Integration.GitKraken.Entities;
using GloToolz.Integration.GitKraken.Segments;
using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace GloToolz.Http
{
    internal static class OAuth
    {
        private static OAuthTokenEntity AccessToken = null;

        private static HttpListener _listener;

        public static string LastErrorMessage = "";

        public static async Task Authenticate()
        {
            string redirect_URL = ConfigurationManager.AppSettings.Get("OAUTH_REDIRECT");
            string gitkraken_authorize_URL = ConfigurationManager.AppSettings.Get("GITKRAKEN_AUTHORIZE");
            string gitkraken_accessToken_URL = ConfigurationManager.AppSettings.Get("GITKRAKEN_ACCESSTOKEN");
            string clientID = ConfigurationManager.AppSettings.Get("OAUTH_CLIENTID");
            string clientSecret = ConfigurationManager.AppSettings.Get("OAUTH_SECRET");
            int loginTimeout = int.Parse(ConfigurationManager.AppSettings.Get("APP_LOGIN_TIMEOUT"));

            string state = randomB64(32);

            _listener = new HttpListener();
            _listener.Prefixes.Add(redirect_URL);
            _listener.Start();

            string request_URL = string.Format("{0}?response_type=code&scope=board:write user:read&state={1}&client_id={2}", new object[] {
                gitkraken_authorize_URL,
                state,
                clientID
            });

            System.Diagnostics.Process.Start(request_URL);

            Timer timeoutTimer = new Timer
            {
                Enabled = true,
                AutoReset = false,
                Interval = loginTimeout
            };
            timeoutTimer.Elapsed += new ElapsedEventHandler(StopListening);

            HttpListenerContext requestContext = null;

            try
            {
                requestContext = await _listener.GetContextAsync();
            }
            catch (HttpListenerException)
            {
                SendPage("UI\\HTML\\OAuthErrorPage.html", requestContext.Response);
                    requestContext.Response.StatusCode = 500; ;
                LastErrorMessage = "You took too long to login. Try again.";

                return;
            }

            OAuthCodeEntity oAuthResponse = OAuthCodeEntity.CreateEntity(requestContext.Request);

            if (!state.Equals(oAuthResponse.State))
            {
                SendPage("UI\\HTML\\OAuthErrorPage.html", requestContext.Response);
                requestContext.Response.StatusCode = 500;

                throw new OAuthException("Error Validation Token. Please Try Again.");
            }
            else
            {
                SendPage("UI\\HTML\\OAuthSuccessPage.html", requestContext.Response);
                requestContext.Response.StatusCode = 200;
            }

            requestContext.Response.Close();
            _listener.Stop();

            AccessTokenSegment tokenRequestBody = new AccessTokenSegment("authorization_code", clientID, clientSecret, oAuthResponse.Code);

            HttpRequest<AccessTokenSegment> tokenRequest = new HttpRequest<AccessTokenSegment>(gitkraken_accessToken_URL, HttpMethod.Post, tokenRequestBody, null, AccessToken);

            AccessToken = await Requesting.MakeRequest<OAuthTokenEntity>(tokenRequest);
        }

        public static bool isAuthenticated()
        {
            return AccessToken != null;
        }

        #region Helpers
        private static void SendPage(string fileDir, HttpListenerResponse response)
        {
            var page = File.ReadAllText(fileDir);
            var buffer = Encoding.UTF8.GetBytes(page);
            response.ContentLength64 = buffer.Length;
            var responseOutput = response.OutputStream;
            Task responseTask = responseOutput.WriteAsync(buffer, 0, buffer.Length).ContinueWith((task) =>
            {
                responseOutput.Close();
                _listener.Stop();
            });
        }

        private static void StopListening(object src, ElapsedEventArgs e)
        {
            _listener.Stop();
        }

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