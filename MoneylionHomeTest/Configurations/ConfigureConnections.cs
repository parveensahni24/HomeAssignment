using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoneylionHomeTest.Data;
using MoneylionHomeTest.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneylionHomeTest.Configurations
{
    public static class ConfigureConnections
    {
        public static IServiceCollection AddConnectionProvider(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connection = configuration.GetSection("ConnectionStrings")["PostgreSqlConnection"];

            services.AddDbContext<PostgreSqlContext>(options => options.UseNpgsql(connection));            

            return services;
        }
    }
}
