using adams_repository_client.Utils;
using NAVIAIServices.RepositoryService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace adams_repository_client
{
    internal class RepositoryClient : IRepositoryClient
    {
        private Uri _baseUri;
        private string _token;

        public RepositoryClient(string baseUrl)
        {
            _baseUri = new Uri(baseUrl);
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = _baseUri;
                var httpResponse = await client.PostAsync($"/login/{username}/{password}", null);
                string httpResponseContent = await httpResponse.Content.ReadAsStringAsync();
                _token = httpResponseContent;
                return true;
            }
        }

        public async Task<List<Project>> GetProjectsAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = _baseUri;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                var httpResponse = await client.GetAsync($"/projects");
                if (httpResponse.Content is object && httpResponse.Content.Headers.ContentType.MediaType == "application/json")
                {
                    var convert = new ResponseConverter<List<Project>>(httpResponse.Content);
                    return convert.Convert();
                }
                else
                {
                    Console.WriteLine("HTTP Response was invalid and cannot be deserialised.");
                }
                return null;
            }
        }

        public async Task<Project> GetProjectAsync(string projectId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = _baseUri;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                var httpResponse = await client.GetAsync($"/projects/{projectId}");
                if (httpResponse.Content is object && httpResponse.Content.Headers.ContentType.MediaType == "application/json")
                {
                    var convert = new ResponseConverter<Project>(httpResponse.Content);
                    return convert.Convert();
                }
                else
                {
                    Console.WriteLine("HTTP Response was invalid and cannot be deserialised.");
                }
                return null;
            }
        }
    }
}
