using NorthWind.Sales.Entities.POCOEntities;
using NorthWind.Sales.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Entities.Aggregates
{
    public class OrderAggregate :Order
    {
        readonly List<OrderDetail> OrderDetailsField = new List<OrderDetail>();

        public IReadOnlyCollection<OrderDetail> OrderDetails => OrderDetailsField;

        public void AddDetail(OrderDetail orderDetail)
        {
            var ExistingOrderDetail = OrderDetailsField.FirstOrDefault(o => o.ProductId == orderDetail.ProductId);
            if (ExistingOrderDetail != null)
            {
                var NewOrderDetail = ExistingOrderDetail.AddQuantity(orderDetail.Quantity);

                OrderDetailsField.Remove(ExistingOrderDetail);
                OrderDetailsField.Add(NewOrderDetail);
            }
            else
            {
                OrderDetailsField.Add(orderDetail);
            }
        }
    }
}
