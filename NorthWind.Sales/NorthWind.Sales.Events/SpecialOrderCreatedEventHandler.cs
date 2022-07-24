using NorthWind.Entities.Interfaces;
using NorthWind.Entities.Interfaces.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Events
{
    public class SpecialOrderCreatedEventHandler : IDomainEventHandler<SpecialOrderCreatedEvent>
    {
        readonly IMailService MailService;

        public SpecialOrderCreatedEventHandler(IMailService mailService)
        {
            MailService = mailService;
        }

        public void Handle(SpecialOrderCreatedEvent orderCreated)
        {
            MailService.Send($"Orden {orderCreated.OrderId} con {orderCreated.ProductsCount} productos");
        }
    }
}
