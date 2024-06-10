using ServerManagement.Models;

namespace ServerManagement
{
    public class ServersRepository : IServersRepository
    {
        private List<Server> servers =
        [
            new Server {  ServerId = 1, Name = "Server1", City = "Toronto" },
            new Server {  ServerId = 2, Name = "Server2", City = "Toronto" },
            new Server {  ServerId = 3, Name = "Server3", City = "Toronto" },
            new Server {  ServerId = 4, Name = "Server4", City = "Toronto" },
            new Server {  ServerId = 5, Name = "Server5", City = "Montreal" },
            new Server {  ServerId = 6, Name = "Server6", City = "Montreal" },
            new Server {  ServerId = 7, Name = "Server7", City = "Montreal" },
            new Server {  ServerId = 8, Name = "Server8", City = "Ottawa" },
            new Server {  ServerId = 9, Name = "Server9", City = "Ottawa" },
            new Server {  ServerId = 10, Name = "Server10", City = "Calgary" },
            new Server {  ServerId = 11, Name = "Server11", City = "Calgary" },
            new Server {  ServerId = 12, Name = "Server12", City = "Halifax" },
            new Server {  ServerId = 13, Name = "Server13", City = "Halifax" },
            new Server {  ServerId = 14, Name = "Server14", City = "Halifax" },
            new Server {  ServerId = 15, Name = "Server15", City = "Halifax" },
        ];

        public Task AddServer(Server server)
        {
            var maxId = servers.Max(s => s.ServerId);
            server.ServerId = maxId + 1;
            servers.Add(server);

            return Task.CompletedTask;
        }

        public Task<List<Server>> GetServers() => Task.FromResult(servers);

        public Task<List<Server>> GetServersByCity(string cityName)
        {
            return Task.FromResult(servers.Where(s => s.City.Equals(cityName, StringComparison.OrdinalIgnoreCase)).ToList());
        }

        public Task<Server?> GetServerById(int id)
        {
            var server = servers.FirstOrDefault(s => s.ServerId == id);
            if (server != null)
            {
                return Task.FromResult<Server?>(new Server
                {
                    ServerId = server.ServerId,
                    Name = server.Name,
                    City = server.City,
                    IsOnline = server.IsOnline
                });
            }

            return Task.FromResult<Server?>(null);
        }

        public Task UpdateServer(int serverId, Server server)
        {
            if (serverId != server.ServerId) return Task.CompletedTask;

            var serverToUpdate = servers.FirstOrDefault(s => s.ServerId == serverId);

            if (serverToUpdate != null)
            {
                serverToUpdate.IsOnline = server.IsOnline;
                serverToUpdate.Name = server.Name;
                serverToUpdate.City = server.City;
            }

            return Task.CompletedTask;
        }

        public Task DeleteServer(int serverId)
        {
            var server = servers.FirstOrDefault(s => s.ServerId == serverId);

            if (server != null)
            {
                servers.Remove(server);
            }

            return Task.CompletedTask;
        }

        public Task<List<Server>> SearchServers(string serverFilter)
        {
            return Task.FromResult(servers.Where(s => s.Name.Contains(serverFilter, StringComparison.OrdinalIgnoreCase)).ToList());
        }
    }
}
