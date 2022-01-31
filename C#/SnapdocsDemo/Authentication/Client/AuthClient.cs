using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Authentication.Model;

namespace SnapdocsDemo.Authentication.Client
{
    public class AuthClient
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly NameValueCollection _appSettings = ConfigurationManager.AppSettings;

        public AuthClient()
        {
            var authUrl = _appSettings["AuthUrl"];
            _client.BaseAddress = new Uri(authUrl);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> GenerateToken(OauthTokenBody body)
        {
            HttpResponseMessage responsePost = await _client.PostAsJsonAsync("/oauth/token", body);
            if (responsePost.IsSuccessStatusCode)
            {
                var response200 = await responsePost.Content.ReadAsAsync<AuthSuccessResponse>();
                return response200.AccessToken;
            }

            throw new Exception("Token could not be generated: " + responsePost.ReasonPhrase);
        }
    }
}
