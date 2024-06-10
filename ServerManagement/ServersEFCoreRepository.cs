using Microsoft.EntityFrameworkCore;
using ServerManagement.Data;
using ServerManagement.Models;

namespace ServerManagement
{
    public class ServersEFCoreRepository : IServersRepository
    {
        private readonly IDbContextFactory<ServerManagementContext> contextFactory;

        public ServersEFCoreRepository(IDbContextFactory<ServerManagementContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public async Task AddServer(Server server)
        {
            using var db = contextFactory.CreateDbContext();

            await db.Servers.AddAsync(server);

            await db.SaveChangesAsync();
        }

        public async Task DeleteServer(int serverId)
        {
            using var db = contextFactory.CreateDbContext();

            Server? server = await db.Servers.FindAsync(serverId);

            if (server is not null)
            {
                db.Servers.Remove(server);

                await db.SaveChangesAsync();
            }
        }

        public async Task<Server?> GetServerById(int id)
        {
            using var db = contextFactory.CreateDbContext();

            Server? server = await db.Servers.FindAsync(id);

            return server;
        }

        public Task<List<Server>> GetServers()
        {
            using var db = contextFactory.CreateDbContext();

            return db.Servers.ToListAsync();
        }

        public async Task<List<Server>> GetServersByCity(string cityName)
        {
            using var db = contextFactory.CreateDbContext();

            List<Server> servers = await db.Servers.Where(s => s.City == cityName).ToListAsync();
            
            return servers;
        }

        public Task<List<Server>> SearchServers(string serverFilter)
        {
            using var db = contextFactory.CreateDbContext();

            return db.Servers.Where(s => s.Name.ToLower().IndexOf(serverFilter.ToLower()) >= 0).ToListAsync();
        }

        public async Task UpdateServer(int serverId, Server server)
        {
            using var db = contextFactory.CreateDbContext();

            Server? serverToUpdate = await db.Servers.FindAsync(serverId);

            if (serverToUpdate is not null)
            {
                serverToUpdate.Name = server.Name;
                serverToUpdate.City = server.City;
                serverToUpdate.IsOnline = server.IsOnline;

                db.Servers.Update(serverToUpdate);

                await db.SaveChangesAsync();
            }
        }
    }
}
