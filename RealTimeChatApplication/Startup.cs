using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using RealTimeChatApplication.Hubs;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace RealTimeChatApplication
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
            => services.AddSignalR();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
                endpoints.MapHub<ChatHub>("/chat"));
        }
    }
}
