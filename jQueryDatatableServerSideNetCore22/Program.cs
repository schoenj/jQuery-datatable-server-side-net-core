using jQueryDatatableServerSideNetCore22.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace jQueryDatatableServerSideNetCore22
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            IHost host = CreateWebHostBuilder(args).Build();

            // this just automaticly runs the migration on startup
            using (IServiceScope scope = host.Services.CreateScope())
            using (ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
                await context.Database.MigrateAsync();

            await host.RunAsync();
        }

        public static IHostBuilder CreateWebHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webHost => webHost.UseStartup<Startup>());
        }
    }
}