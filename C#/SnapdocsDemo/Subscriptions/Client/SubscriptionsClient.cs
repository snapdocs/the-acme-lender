using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Subscriptions.Model;

namespace SnapdocsDemo.Subscriptions.Client
{
    class SubscriptionsClient
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly NameValueCollection _appSettings = ConfigurationManager.AppSettings;
        public SubscriptionsClient(string token)
        {
            var baseUrl = _appSettings["BaseUrl"];
            _client.BaseAddress = new Uri(baseUrl);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<GetSubscriptions> GetAllSubscriptions()
        {
            var response = await _client.GetAsync("/api/v1/subscriptions");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<GetSubscriptions>();
            }

            throw new Exception("Subscriptions could not be retrieved: " + response.ReasonPhrase);
        }

    }
}
