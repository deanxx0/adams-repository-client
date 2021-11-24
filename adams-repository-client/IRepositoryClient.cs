using adams_repository_service.Models;
using NAVIAIServices.RepositoryService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adams_repository_client
{
    public interface IRepositoryClient
    {
        Task<bool> LoginAsync(string username, string password);
        Task<Project> CreateProjectAsync(CreateProjectModel createProjectModel);
        Task<List<Project>> GetProjectsAsync();
        Task<Project> GetProjectAsync(string projectId);
        Task<InputChannel> CreateChannelAsync(string projectId, CreateChannelModel createChannelModel);
        Task<List<InputChannel>> GetChannelsAsync(string projectId);
        Task<InputChannel> DeleteChannel(string projectId, string channelId);
    }
}
