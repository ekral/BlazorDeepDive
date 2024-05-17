using ServerManagement.Models;

namespace ServerManagement
{
    public interface IServersRepository
    {
        void AddServer(Server server);
        void DeleteServer(int serverId);
        Server? GetServerById(int id);
        List<Server> GetServersByCity(string cityName);
        List<Server> GetServres();
        List<Server> SearchServers(string serverFilter);
        void UpdateServer(int serverId, Server server);
    }
}