using Microsoft.Extensions.DependencyInjection;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileFinder.Infrastructure.Presistence.Elastic.Extensions
{
    public static class ElasticExtensions
    {
        public static IServiceCollection AddElasticSearch(this IServiceCollection services, ConnectionSettings connectionSettings)
        {
            services.AddSingleton<IElasticClient>(provider =>
            {
                return new ElasticClient(connectionSettings);
            });
            return services;
        }

    }
}
