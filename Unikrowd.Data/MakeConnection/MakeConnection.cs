using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Unikrowd.Data.Context;

namespace Unikrowd.Data.MakeConnection
{
    public static class MakeConnection
    {
        public static IServiceCollection ConnectToConnectionString(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UnikrowdContext>(options =>
            {              
                options.UseSqlServer(configuration.GetConnectionString("SQLServerDatabase"));
            });
            return services;
        }
    }
}
