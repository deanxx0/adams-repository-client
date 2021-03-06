using NAVIAIServices.RepositoryService.Entities;
using NAVIAIServices.RepositoryService.Enums;
using System;
using System.Collections.Generic;
using System.Text.Json;
using adams_repository_service.Models;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            var repositoryClient = adams_repository_client.RepositoryClientFactory.Create("http://localhost:5005");

            var loginResult = repositoryClient.LoginAsync("u1", "123").Result;

            //var projects = repositoryClient.GetProjectsAsync().Result;

            //var project = repositoryClient.GetProjectAsync("4cb5bdd0-3669-4dcf-8d5c-9e2fbd0305f2").Result;

            //var createProjectModel = new CreateProjectModel("pp2", "descdesc", NAVIAITypes.Mercury);
            //var project = repositoryClient.CreateProjectAsync(createProjectModel).Result;

            var createChannelModel = new CreateChannelModel("c23", true, "desdes", "rr");
            var channel = repositoryClient.CreateChannelAsync("4cb5bdd0-3669-4dcf-8d5c-9e2fbd0305f2", createChannelModel).Result;

            //var channels = repositoryClient.GetChannelsAsync("4cb5bdd0-3669-4dcf-8d5c-9e2fbd0305f2").Result;

            //var deleteChannel = repositoryClient.DeleteChannelAsync("4cb5bdd0-3669-4dcf-8d5c-9e2fbd0305f2", "c80eb82c-152c-45e3-a01b-508c550a6b40").Result;

            //var createClassInfoModel = new CreateClassInfoModel("ci1", "desdesdes", 0, 0, 0);
            //var classInfo = repositoryClient.CreateClassInfoAsync("4cb5bdd0-3669-4dcf-8d5c-9e2fbd0305f2", createClassInfoModel).Result;

            //var classInfo = repositoryClient.GetClassInfosAsync("4cb5bdd0-3669-4dcf-8d5c-9e2fbd0305f2").Result;

            //var classInfo = repositoryClient.DeleteClassInfoAsync("4cb5bdd0-3669-4dcf-8d5c-9e2fbd0305f2", "7e97ef8c-0c38-4c34-a57d-2bd9e222580b").Result;

            //var createMetadataKey = new CreateMetadataKeyModel("k20", "kkk", "string");
            //var metadataKey = repositoryClient.CreateMetadataKey("4cb5bdd0-3669-4dcf-8d5c-9e2fbd0305f2", createMetadataKey);

            //var metadataKeys = repositoryClient.GetMetadataKeys("4cb5bdd0-3669-4dcf-8d5c-9e2fbd0305f2");

            //var metadataKey = repositoryClient.DeleteMetadataKey("4cb5bdd0-3669-4dcf-8d5c-9e2fbd0305f2", "10d30f39-52c8-4d5e-a0e2-799a94cb9043");

            //Person person = new Person { Id = 1, Name = "nnn" };
            //string jsonPerson = JsonSerializer.Serialize(person);
            //Console.WriteLine(jsonPerson);
            //Console.WriteLine("___________________");
            //string jsonString = "{\"Id\":1,\"Name\":\"Alex\"}";
            //var personObj = JsonSerializer.Deserialize<Person>(jsonString);
            //Console.WriteLine($"{personObj.Id}, {personObj.Name}");
        }
    }
}
