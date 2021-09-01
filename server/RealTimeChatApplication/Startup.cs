using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using RealTimeChatApplication.Hubs;
using Microsoft.Extensions.Hosting;
using RealTimeChatApplication.Models;
using Microsoft.Extensions.DependencyInjection;

namespace RealTimeChatApplication
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder
                        .WithOrigins("http://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });

            services.AddSingleton<IDictionary<string, UserConnection>>(options =>
                new Dictionary<string, UserConnection>());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting()
                .UseCors()
                .UseEndpoints(endpoints =>
                    endpoints.MapHub<ChatHub>("/chat"));
        }
    }
}
