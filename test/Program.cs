using adams_repository_service.Models;
using NAVIAIServices.RepositoryService.Entities;
using NAVIAIServices.RepositoryService.Enums;
using System;
using System.Collections.Generic;

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

            //var createProjectModel = new CreateProjectModel("pp1", "descdesc", NAVIAITypes.Mercury);
            //var project = repositoryClient.CreateProjectAsync(createProjectModel).Result;

            //var createChannelModel = new CreateChannelModel("c1", true, "desdes", "rr");
            //var channel = repositoryClient.CreateChannelAsync("4cb5bdd0-3669-4dcf-8d5c-9e2fbd0305f2", createChannelModel).Result;

            //var channels = repositoryClient.GetChannelsAsync("4cb5bdd0-3669-4dcf-8d5c-9e2fbd0305f2").Result;

            //var deleteChannel = repositoryClient.DeleteChannelAsync("4cb5bdd0-3669-4dcf-8d5c-9e2fbd0305f2", "c80eb82c-152c-45e3-a01b-508c550a6b40").Result;

            //var createClassInfoModel = new CreateClassInfoModel("ci1", "desdesdes", 0, 0, 0);
            //var classInfo = repositoryClient.CreateClassInfoAsync("4cb5bdd0-3669-4dcf-8d5c-9e2fbd0305f2", createClassInfoModel).Result;

            //var classInfo = repositoryClient.GetClassInfosAsync("4cb5bdd0-3669-4dcf-8d5c-9e2fbd0305f2").Result;

            //var classInfo = repositoryClient.DeleteClassInfoAsync("4cb5bdd0-3669-4dcf-8d5c-9e2fbd0305f2", "7e97ef8c-0c38-4c34-a57d-2bd9e222580b").Result;

        }
    }
}
