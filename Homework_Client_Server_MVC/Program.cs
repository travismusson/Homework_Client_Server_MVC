using Microsoft.EntityFrameworkCore;
using Homework_Client_Server_MVC.Hubs;
using Microsoft.AspNetCore.SignalR;
using Homework_Client_Server_MVC.Data;

namespace Homework_Client_Server_MVC
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSignalR();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ChatHub"))); 

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.MapHub<ChatHub>("/chat-hub"); // Map the ChatHub to the "chat-hub" endpoint
            app.MapPost("broadcast", async (string message, IHubContext<ChatHub, ChatClient> context) =>
            {
                await context.Clients.All.ReceiveMessage("Server", message); // Broadcast the message to all connected clients
                return Results.NoContent();
            });

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
