using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace WebAssemblyDemo.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services.AddSingleton<ContainerStorage>();

            await builder.Build().RunAsync();
        }
    }
}
