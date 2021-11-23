using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adams_repository_client
{
    public static class RepositoryClientFactory
    {
        public static IRepositoryClient Create(string baseUrl)
        {
            return new RepositoryClient(baseUrl);
        }
    }
}
