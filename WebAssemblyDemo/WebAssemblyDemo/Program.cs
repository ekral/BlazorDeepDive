using WebAssemblyDemo.Client;
using WebAssemblyDemo.Client.Models;
using WebAssemblyDemo.Client.Pages;
using WebAssemblyDemo.Components;

namespace WebAssemblyDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //builder.Services.AddScoped(sp =>
            // {
            //     HttpClient client = new() { BaseAddress = new Uri("https://webassembly-demo-aa095-default-rtdb.europe-west1.firebasedatabase.app") };

            //     client.DefaultRequestHeaders.Add("Accept", "application/json");

            //     return client;
            // });

            builder.Services.AddHttpClient("webapi", client =>
            {
                client.BaseAddress = new Uri("https://webassembly-demo-aa095-default-rtdb.europe-west1.firebasedatabase.app");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            builder.Services.AddScoped<Client.Models.IServersRepository, ServersApiRepository>();

            // Add services to the container.
            builder.Services
                .AddSingleton<ContainerStorage>()
                .AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddInteractiveWebAssemblyComponents();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

            app.Run();
        }
    }
}
