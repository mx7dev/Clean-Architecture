using NorthWind.Entities.Interfaces.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Events
{
    public class SpecialOrderCreatedEvent : IDomainEvent
    {
        public SpecialOrderCreatedEvent(int orderId, int productsCount)
        {
            OrderId = orderId;
            ProductsCount = productsCount;
        }

        public int OrderId { get; set; }
        public int  ProductsCount { get; set; }

    }
}
