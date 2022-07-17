using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthWind.Entities.Interfaces.Validation;
using NorthWind.Sales.DTOs.CreateOrder;

namespace NorthWind.Sales.DTOs
{
    public  static class DependencyContainer
    {
        public static IServiceCollection AddDTOValidators(
            this IServiceCollection services)
        {
            services.AddScoped <IValidator<CreateOrderDetailDTO>, CreateOrderDetailDTOValidator>();

            services.AddScoped<IValidator<CreateOrderDTO>, CreateOrderDTOValidator>();

            return services;
        }

    }
}
