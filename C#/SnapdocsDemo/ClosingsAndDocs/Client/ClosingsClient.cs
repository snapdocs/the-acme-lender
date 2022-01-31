using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ClosingsAndDocs.Model;

namespace SnapdocsDemo.ClosingsAndDocs.Client
{
    public class ClosingsClient
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly NameValueCollection _appSettings = ConfigurationManager.AppSettings;
        public ClosingsClient(string token)
        {
            var baseUrl = _appSettings["BaseUrl"];
            _client.BaseAddress = new Uri(baseUrl);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<Closing> CreateClosing(NewClosingStandard body)
        {

            var response = await _client.PostAsJsonAsync("/api/v1/closings", body);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<Closing>();
            }

            throw new Exception("Closing could not be created: " + response.ReasonPhrase);
        }
    }
}
