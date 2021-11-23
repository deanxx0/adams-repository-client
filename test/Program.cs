using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            var repositoryClient = adams_repository_client.RepositoryClientFactory.Create("http://localhost:5005");

            repositoryClient.LoginAsync("u1", "123").Wait();

            //var projects = repositoryClient.GetProjectsAsync().Result;

            var project = repositoryClient.GetProjectAsync("ad4abf8c-acca-4204-b00f-3909478b0175").Result;
        }
    }
}
