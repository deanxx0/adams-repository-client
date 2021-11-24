using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace adams_repository_client.Utils
{
    class HttpRequester<T>
    {
        HttpClient _httpClient;

        public HttpRequester(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        internal async Task<T> PostAsync(string targetUrl, string projectId, object createModel)
        {
            using (var response = await _httpClient.PostAsJsonAsync($"/projects/{projectId}/{targetUrl}", createModel))
            {
                if (response.Content is object && response.Content.Headers.ContentType.MediaType == "application/json")
                {
                    var convert = new ResponseConverter<T>(response.Content);
                    return convert.Convert();
                }
                else
                {
                    Console.WriteLine("HTTP Response was invalid and cannot be deserialised.");
                }
                return default(T);
            }
        }

        internal async Task<List<T>> GetListAsync(string targetUrl, string projectId)
        {
            var modelList = await _httpClient.GetFromJsonAsync<List<T>>($"/projects/{projectId}/{targetUrl}");
            return modelList;
        }

        internal async Task<T> DeleteAsync(string targetUrl, string projectId, string modelId)
        {
            using (var response = await _httpClient.DeleteAsync($"projects/{projectId}/{targetUrl}/{modelId}"))
            {
                if (response.Content is object && response.Content.Headers.ContentType.MediaType == "application/json")
                {
                    var convert = new ResponseConverter<T>(response.Content);
                    return convert.Convert();
                }
                else
                {
                    Console.WriteLine("HTTP Response was invalid and cannot be deserialised.");
                }
                return default(T);
            }
        }
    }
}
