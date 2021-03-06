using adams_repository_client.Utils;
using adams_repository_service.Models;
using NAVIAIServices.RepositoryService.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace adams_repository_client
{
    internal class RepositoryClient : IRepositoryClient
    {
        private Uri _baseUri;
        //private string _token;
        private readonly HttpClient _httpClient;

        public RepositoryClient(string baseUrl)
        {
            _baseUri = new Uri(baseUrl);
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = _baseUri;
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            using (var response = await _httpClient.PostAsync($"/login/{username}/{password}", null))
            {
                if (HttpStatusCode.OK == response.StatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var token = responseContent;
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    return true;
                }
                return false;
            }
            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = _baseUri;
            //    var httpResponse = await client.PostAsync($"/login/{username}/{password}", null);
            //    string httpResponseContent = await httpResponse.Content.ReadAsStringAsync();
            //    _token = httpResponseContent;
            //    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            //    return true;
            //}
        }

        public async Task<Project> CreateProjectAsync(CreateProjectModel createProjectModel)
        {
            using (var response = await _httpClient.PostAsJsonAsync($"/projects", createProjectModel))
            {
                if (response.Content is object && response.Content.Headers.ContentType.MediaType == "application/json")
                {
                    var convert = new ResponseConverter<Project>(response.Content);
                    return convert.Convert();
                }
                else
                {
                    Console.WriteLine("HTTP Response was invalid and cannot be deserialised.");
                }
                return null;
            }
        }

        public async Task<List<Project>> GetProjectsAsync()
        {
            var projects = await _httpClient.GetFromJsonAsync<List<Project>>($"/projects");
            return projects;

            //var httpResponse = await _httpClient.GetAsync($"/projects");
            //if (httpResponse.Content is object && httpResponse.Content.Headers.ContentType.MediaType == "application/json")
            //{
            //    var convert = new ResponseConverter<List<Project>>(httpResponse.Content);
            //    return convert.Convert();
            //}
            //else
            //{
            //    Console.WriteLine("HTTP Response was invalid and cannot be deserialised.");
            //}
            //return null;

            //using (var client = new HttpClient())
            //{
            //    //client.BaseAddress = _baseUri;
            //    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            //    var httpResponse = await client.GetAsync($"/projects");
            //    if (httpResponse.Content is object && httpResponse.Content.Headers.ContentType.MediaType == "application/json")
            //    {
            //        var convert = new ResponseConverter<List<Project>>(httpResponse.Content);
            //        return convert.Convert();
            //    }
            //    else
            //    {
            //        Console.WriteLine("HTTP Response was invalid and cannot be deserialised.");
            //    }
            //    return null;
            //}
        }

        public async Task<Project> GetProjectAsync(string projectId)
        {
            var project = await _httpClient.GetFromJsonAsync<Project>($"/projects/{projectId}");
            return project;

            //using (var client = new HttpClient())
            //{
            //    //client.BaseAddress = _baseUri;
            //    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            //    var httpResponse = await client.GetAsync($"/projects/{projectId}");
            //    if (httpResponse.Content is object && httpResponse.Content.Headers.ContentType.MediaType == "application/json")
            //    {
            //        var convert = new ResponseConverter<Project>(httpResponse.Content);
            //        return convert.Convert();
            //    }
            //    else
            //    {
            //        Console.WriteLine("HTTP Response was invalid and cannot be deserialised.");
            //    }
            //    return null;
            //}
        }

        public async Task<InputChannel> CreateChannelAsync(string projectId, CreateChannelModel createChannelModel)
        {
            using (var response = await _httpClient.PostAsJsonAsync($"/projects/{projectId}/channels", createChannelModel))
            {
                if (response.Content is object && response.Content.Headers.ContentType.MediaType == "application/json")
                {
                    var convert = new ResponseConverter<InputChannel>(response.Content);
                    return convert.Convert();
                }
                else
                {
                    Console.WriteLine("HTTP Response was invalid and cannot be deserialised.");
                }
                return null;
            }
        }

        public async Task<List<InputChannel>> GetChannelsAsync(string projectId)
        {
            var channels = await _httpClient.GetFromJsonAsync<List<InputChannel>>($"/projects/{projectId}/channels");
            return channels;
        }

        public async Task<InputChannel> DeleteChannelAsync(string projectId, string channelId)
        {
            using (var response = await _httpClient.DeleteAsync($"projects/{projectId}/channels/{channelId}"))
            {
                if (response.Content is object && response.Content.Headers.ContentType.MediaType == "application/json")
                {
                    var convert = new ResponseConverter<InputChannel>(response.Content);
                    return convert.Convert();
                }
                else
                {
                    Console.WriteLine("HTTP Response was invalid and cannot be deserialised.");
                }
                return null;
            }
        }

        public async Task<ClassInfo> CreateClassInfoAsync(string projectId, CreateClassInfoModel createClassInfoModel)
        {
            using (var response = await _httpClient.PostAsJsonAsync($"/projects/{projectId}/classinfos", createClassInfoModel))
            {
                if (response.Content is object && response.Content.Headers.ContentType.MediaType == "application/json")
                {
                    var convert = new ResponseConverter<ClassInfo>(response.Content);
                    return convert.Convert();
                }
                else
                {
                    Console.WriteLine("HTTP Response was invalid and cannot be deserialised.");
                }
                return null;
            }
        }

        public async Task<List<ClassInfo>> GetClassInfosAsync(string projectId)
        {
            var classInfos = await _httpClient.GetFromJsonAsync<List<ClassInfo>>($"/projects/{projectId}/classinfos");
            return classInfos;
        }

        public async Task<ClassInfo> DeleteClassInfoAsync(string projectId, string classInfoId)
        {
            using (var response = await _httpClient.DeleteAsync($"projects/{projectId}/classinfos/{classInfoId}"))
            {
                if (response.Content is object && response.Content.Headers.ContentType.MediaType == "application/json")
                {
                    var convert = new ResponseConverter<ClassInfo>(response.Content);
                    return convert.Convert();
                }
                else
                {
                    Console.WriteLine("HTTP Response was invalid and cannot be deserialised.");
                }
                return null;
            }
        }

        public MetadataKey CreateMetadataKey(string projectId, CreateMetadataKeyModel createMetadataKeyModel)
        {
            var httpRequester = new HttpRequester<MetadataKey>(_httpClient);
            var metadataKey = httpRequester.PostAsync("metadatakeys", projectId, createMetadataKeyModel).Result;
            return metadataKey;
        }

        public List<MetadataKey> GetMetadataKeys(string projectId)
        {
            var httpRequester = new HttpRequester<MetadataKey>(_httpClient);
            var metadataKeys = httpRequester.GetListAsync("metadatakeys", projectId).Result;
            return metadataKeys;
        }

        public MetadataKey DeleteMetadataKey(string projectId, string metadataKeyId)
        {
            var httpRequester = new HttpRequester<MetadataKey>(_httpClient);
            var metadataKey = httpRequester.DeleteAsync("metadatakeys", projectId, metadataKeyId).Result;
            return metadataKey;
        }
    }
}
