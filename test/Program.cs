using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            var repositoryClient = adams_repository_client.RepositoryClientFactory.Create("http://localhost:5005");

            repositoryClient.LoginAsync("u1", "123").Wait();

            var projects = repositoryClient.GetProjectsAsync().Result;
        }
    }
}
