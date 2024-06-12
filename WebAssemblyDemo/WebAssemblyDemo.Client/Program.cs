using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebAssemblyDemo.Client.Models;

namespace WebAssemblyDemo.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder
                .Services
                .AddSingleton<ContainerStorage>()
                .AddSingleton(sp =>
                {
                    HttpClient client = new() { BaseAddress = new Uri("https://webassembly-demo-aa095-default-rtdb.europe-west1.firebasedatabase.app") };
                    
                    client.DefaultRequestHeaders.Add("Accept", "application/json");

                    return client;
                })
                .AddSingleton<IServersRepository, ServersApiRepository>();

            await builder.Build().RunAsync();
        }
    }
}
