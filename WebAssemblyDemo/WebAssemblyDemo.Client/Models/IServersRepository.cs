
namespace WebAssemblyDemo.Client.Models
{
    public interface IServersRepository
    {
        Task<List<Server>> GetServersAsync();
        Task AddServerAsync(Server server);
        Task<Server> GetServerByIdAsync(int serverId);
        Task UpdateServerAsync(int serverId, Server server);
        Task DeleteServerAsync(int serverId);
    }
}