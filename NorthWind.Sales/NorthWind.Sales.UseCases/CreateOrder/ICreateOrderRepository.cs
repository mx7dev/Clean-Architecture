using NorthWind.Entities.Interfaces;
using NorthWind.Sales.Entities.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.UseCases.CreateOrder
{
    public interface ICreateOrderRepository : IUnitOfWork
    {
        void CreateOrder(OrderAggregate order);
        void CancelChanges();
    }
}
