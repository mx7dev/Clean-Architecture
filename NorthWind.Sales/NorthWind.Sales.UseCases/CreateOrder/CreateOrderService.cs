using NorthWind.Entities.Exceptions;
using NorthWind.Entities.Interfaces;
using NorthWind.Entities.Interfaces.Events;
using NorthWind.Entities.Interfaces.Validation;
using NorthWind.Sales.DTOs.CreateOrder;
using NorthWind.Sales.Entities.Aggregates;
using NorthWind.Sales.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.UseCases.CreateOrder
{
    public class CreateOrderService
    {

        readonly IValidator<CreateOrderDTO> Validator;
        readonly ICreateOrderRepository OrderRepository;
        readonly IDomainEventHub<SpecialOrderCreatedEvent> DomainEventHub;
        readonly ILogWritableRepository LogRepository;

        public CreateOrderService(IValidator<CreateOrderDTO> validator,
            ICreateOrderRepository orderRepository,
            IDomainEventHub<SpecialOrderCreatedEvent> domainEventHub,
            ILogWritableRepository logRepository)
        {
            Validator = validator;
            OrderRepository = orderRepository;
            DomainEventHub = domainEventHub;
            LogRepository = logRepository;
        }

        public void RunValidationGuard(CreateOrderDTO order)
        {
            if (!Validator.Validate(order))
            {
                throw new ValidationException(Validator.Failures);
            }
        }

        public OrderAggregate RunCreateOrderGuard(CreateOrderDTO order)
        {
            OrderAggregate OrderAggregate = new OrderAggregate
            {
                CustomerId = order.CustormerId,
                ShipAddress = order.ShipAddress,
                ShipCity = order.ShipCity,
                ShipPostalCode = order.ShipPostalCode
            };
            foreach (var Item in order.OrderDetails)
            {
                OrderAggregate.AddDetail(Item.ProductId, Item.UnitPrice, Item.Quantity);
            }
            try
            {
                LogRepository.Add("Inicio de creación de orden de compra");
                LogRepository.SaveChanges();

                OrderRepository.CreateOrder(OrderAggregate); //  Devuelve exception
                                                             // si hay error
                                                             // Aquí podriamos tener una lógica 
                                                             // OrderRepository.CancelChanges()

                LogRepository.Add($"Orden {OrderAggregate.Id} creada");
                LogRepository.SaveChanges();

                // Completa la transacacción
                OrderRepository.SaveChanges();

            }
            catch {
                LogRepository.Add("Creación de orden cancelada");
                LogRepository.SaveChanges();
                throw;
            }
            return OrderAggregate;
        }

        public void RaiseEVentIfIsSpecialOrder( OrderAggregate order)
        { 
            if (new SpecialOrderSpecification().IsSatisfiedBy(order))
            {
                DomainEventHub.Raise(new SpecialOrderCreatedEvent(order.Id, order.OrderDetails.Count));
            }
        }
    }
}
