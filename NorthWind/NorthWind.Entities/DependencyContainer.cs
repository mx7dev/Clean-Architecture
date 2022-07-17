using Microsoft.Extensions.DependencyInjection;
using NorthWind.Entities.Interfaces.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entities
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddEntitiesServices(
            this IServiceCollection services)
        {

            services.AddScoped(typeof(IDomainEventHub<>), typeof(IDomainEventHub<>));
            return services;
        }
    }
}
