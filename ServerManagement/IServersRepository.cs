using ServerManagement.Models;

namespace ServerManagement
{
    public interface IServersRepository
    {
        Task AddServer(Server server);
        Task DeleteServer(int serverId);
        Task<Server?> GetServerById(int id);
        Task<List<Server>> GetServersByCity(string cityName);
        Task<List<Server>> GetServers();
        Task<List<Server>> SearchServers(string serverFilter);
        Task UpdateServer(int serverId, Server server);
    }
}