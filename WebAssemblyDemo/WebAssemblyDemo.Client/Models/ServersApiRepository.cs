using System.Net.Http.Json;
using System.Linq;
using System.Text.Json;
using System.Text;

namespace WebAssemblyDemo.Client.Models
{
    public class ServersApiRepository : IServersRepository
    {
        private readonly HttpClient client;

        public ServersApiRepository(HttpClient client)
        {
            this.client = client;
        }

        public async Task<List<Server>> GetServersAsync()
        {
            HttpResponseMessage response = await client.GetAsync("servers.json");

            if (response.IsSuccessStatusCode)
            {
                List<Server>? servers = await response.Content.ReadFromJsonAsync<List<Server>>();

                if (servers is not null)
                {
                    return servers;
                }
            }

            return new List<Server>();
        }

        public async Task<Server> GetServerByIdAsync(int serverId)
        {
            HttpResponseMessage response = await client.GetAsync($"servers/{serverId}.json");

            if (response.IsSuccessStatusCode)
            {
                Server? server = await response.Content.ReadFromJsonAsync<Server>();

                if (server is not null)
                {
                    return server;
                }
            }

            return new Server();
        }

        public async Task AddServerAsync(Server server)
        {
            List<Server> servers = await GetServersAsync();
            server.ServerId = servers.Where(server => server is not null).Max(server => server.ServerId) + 1;
            
            StringContent content = new StringContent(JsonSerializer.Serialize(server), Encoding.UTF8, "application/json");
            
            var response = await client.PutAsync($"servers/{server.ServerId}.json", content);

            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateServerAsync(int serverId, Server server)
        {
            if(serverId != server.ServerId)
            {
                return;
            }

            StringContent content = new StringContent(JsonSerializer.Serialize(server), Encoding.UTF8, "application/json");

            var response = await client.PatchAsync($"servers/{server.ServerId}.json", content);

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteServerAsync(int serverId)
        {
            HttpResponseMessage response = await client.DeleteAsync($"servers/{serverId}.json");
        }
    }
}
