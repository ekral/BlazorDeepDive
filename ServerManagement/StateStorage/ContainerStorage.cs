using ServerManagement.Models;

namespace ServerManagement.StateStorage
{
    public class ContainerStorage : IStorage
    {
        private Server server = new Server() { City = string.Empty, Name = string.Empty };

        public Task<Server?> GetServerAsync()
        {
            return Task.FromResult<Server?>(server);
        }

        public Task SetServerAsync(Server server)
        {
            this.server = server;

            return Task.CompletedTask;
        }
    }
}
