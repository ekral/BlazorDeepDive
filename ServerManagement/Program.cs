using CommunityToolkit.Mvvm.Messaging;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using ServerManagement.Components;
using ServerManagement.Data;
using ServerManagement.StateStorage;

namespace ServerManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContextFactory<ServerManagementContext>(options =>
            {
                string? connectionString = builder.Configuration.GetConnectionString("ServerManagement");
                options.UseSqlServer(connectionString);
            });

            // Add services to the container.
            builder.Services.AddRazorComponents()
                    .AddInteractiveServerComponents();

            builder.Services
                .AddSingleton<IServersRepository, ServersEFCoreRepository>()
                .AddSingleton<ICitiesRepository, CitiesRepository>()
                .AddTransient<ProtectedSessionStorage>()
                .AddScoped<IStorage, ContainerStorage>()
                .AddScoped<IMessenger, WeakReferenceMessenger>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();
           
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
