using ServerManagement.Models;

namespace ServerManagement.StateStorage
{
    public interface IStorage
    {
        Task<Server?> GetServerAsync();
        Task SetServerAsync(Server server);
    }
}