using adams_repository_service.Models;
using NAVIAIServices.RepositoryService.Enums;
using System;

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

            var createProjectModel = new CreateProjectModel("pp1", "descdesc", NAVIAITypes.Mercury);
            var project = repositoryClient.CreateProjectAsync(createProjectModel).Result;
        }
    }
}
