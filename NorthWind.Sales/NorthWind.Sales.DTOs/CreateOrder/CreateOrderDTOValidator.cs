using NorthWind.Entities.Abstractions;
using NorthWind.Entities.Interfaces.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.DTOs.CreateOrder
{
    public class CreateOrderDTOValidator : ValidatorBase<CreateOrderDTO>
    {
        public CreateOrderDTOValidator(IValidationService<CreateOrderDTO> service,
            IValidationService<CreateOrderDetailDTO> orderDetailValidationService
            ) : base(service)
        {
            AddRuleFor(o => o.CustormerId)
                .AddRequirement(o => !string.IsNullOrWhiteSpace(o.CustormerId), "Debe proporcionar el identificador del cliente")
                .AddRequirement(o => o.CustormerId.Length == 5, "La Longitud del identificador debe ser 5");

            AddRuleFor(o => o.ShipAddress)
              .AddRequirement(o => !string.IsNullOrWhiteSpace(o.ShipAddress), "Debe proporcionar la direccion de envío")
              .AddRequirement(o => o.ShipAddress.Length <=60, "La Longitud máxima de la dirección es 60");

            AddRuleFor(o => o.ShipCity)
               .AddRequirement(o => !string.IsNullOrWhiteSpace(o.ShipCity), "Debe proporcionar la ciudad de envío.")
               .AddRequirement(o => o.ShipCity.Length >= 3, "Debe especificar al menos 3 caracteres del nombre de la ciudad.")
               .AddRequirement(o => o.ShipCity.Length <= 15, "La longitud máxima de la ciudad es 15");

            AddRuleFor(o => o.ShipCountry)
               .AddRequirement(o => !string.IsNullOrWhiteSpace(o.ShipCountry), "Debe proporcionar el país de envío.")
               .AddRequirement(o => o.ShipCountry.Length >= 3, "Debe especificar al menos 3 caracteres del nombre del pais.")
               .AddRequirement(o => o.ShipCountry.Length <= 15, "La longitud máxima del pais es 15");

            AddRuleFor(o => o.ShipPostalCode)
               .AddRequirement(o => o.ShipPostalCode.Length <= 10, "La longitud máxima del código postal es 10");

            AddRuleFor(o => o.OrderDetails)
                .AddRequirement(o => o.OrderDetails != null, "Debe especificar los productos de la orden")
                .AddRequirement(o => o.OrderDetails.Any(), "Debe especificar al menos un producto de la orden")
                .AddRequirement(o => o.OrderDetails.Any(), "Debe especificar al menos un producto de la orden")
                .AddCollectionItemsValidators(o => SetValidatorFor(o.OrderDetails, new CreateOrderDetailDTOValidator(orderDetailValidationService)));
                


        }
    }
}
