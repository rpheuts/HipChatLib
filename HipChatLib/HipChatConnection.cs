using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HipChat
{
    public class HipChatConnection
    {
        private HttpClient _client;
        private readonly JsonSerializerSettings _jsonSettings;

        public HipChatConnection(HipChatCredentials credentials, Uri baseAddress = null)
        {
            _jsonSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

            _client = new HttpClient { BaseAddress = baseAddress ?? new Uri("https://api.hipchat.com/v2/") };
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", credentials.Token);
            _client.DefaultRequestHeaders.Host = "api.hipchat.com";
        }

        public async Task<T> GetRequest<T>(string requestUri)
        {
            var rawResponse = await _client.GetStringAsync(requestUri);

            return JsonConvert.DeserializeObject<T>(rawResponse);
        }

        public async Task<T> GetListRequest<T>(string requestUri)
        {
            var rawResponse = await _client.GetStringAsync(requestUri);
            dynamic context = JsonConvert.DeserializeObject(rawResponse);

            if (context.items == null)
                return default(T);

            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(context.items));
        }

        public async Task<bool> PostRequest(string requestUri, object postObject)
        {
            var json = JsonConvert.SerializeObject(postObject, Formatting.None, _jsonSettings);
            var payload = new StringContent(json, Encoding.UTF8, "application/json");

            var result = await _client.PostAsync(requestUri, payload);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> PutRequest(string requestUri, object postObject)
        {
            var json = JsonConvert.SerializeObject(postObject, Formatting.None, _jsonSettings);
            var payload = new StringContent(json, Encoding.UTF8, "application/json");

            var result = await _client.PutAsync(requestUri, payload);

            return result.IsSuccessStatusCode;
        }
    }
}
