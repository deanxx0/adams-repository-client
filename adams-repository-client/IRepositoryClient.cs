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
        Task<InputChannel> DeleteChannelAsync(string projectId, string channelId);
        Task<ClassInfo> CreateClassInfoAsync(string projectId, CreateClassInfoModel createClassInfoModel);
        Task<List<ClassInfo>> GetClassInfosAsync(string projectId);
        Task<ClassInfo> DeleteClassInfoAsync(string projectId, string classInfoId);
        MetadataKey CreateMetadataKey(string projectId, CreateMetadataKeyModel createMetadataKeyModel);
        List<MetadataKey> GetMetadataKeys(string projectId);
        MetadataKey DeleteMetadataKey(string projectId, string metadataKeyId);
    }
}
