using Microsoft.Extensions.DependencyInjection;
using MoneylionHomeTest.Business.Repositories;
using MoneylionHomeTest.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneylionHomeTest.Configurations
{
    public static class ServicesConfiguration
    {
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IFeatureUsageRepository, FeatureUsageRepository>();
        }
    }
}
