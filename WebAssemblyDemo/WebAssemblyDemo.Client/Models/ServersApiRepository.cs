using System.Net.Http.Json;

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
    }
}
