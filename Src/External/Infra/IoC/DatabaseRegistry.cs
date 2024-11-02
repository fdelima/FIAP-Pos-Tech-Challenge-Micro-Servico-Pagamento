using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FIAP.Pos.Tech.Challenge.Infra.IoC
{
    internal static class DatabaseRegistry
    {
        public static void RegisterDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            //DB Context
            if (bool.Parse(configuration["UseInMemoryDatabase"] ?? "false"))
                services.AddDbContext<Context>(options =>
                    options.UseInMemoryDatabase("MyInMemoryDatabase"));
            else
                services.AddDbContext<Context>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
