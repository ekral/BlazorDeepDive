using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using ServerManagement.Models;

namespace ServerManagement.StateStorage
{
    public class SessionStorage : IStorage
    {
        private const string key = "Server";

        ProtectedSessionStorage sessionStorage;

        public SessionStorage(ProtectedSessionStorage sessionStorage)
        {
            this.sessionStorage = sessionStorage;
        }

        public async Task<Server?> GetServerAsync()
        {
            ProtectedBrowserStorageResult<Server> result = await sessionStorage.GetAsync<Server>(key);

            if (!result.Success)
            {
                return null;
            }

            return result.Value;
        }

        public async Task SetServerAsync(Server server)
        {
            await sessionStorage.SetAsync(key, server);
        }
    }
}
