using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Entities.ValueObjects
{
    public class OrderDetail
    {
        public int ProductId { get; }
        public decimal UnitPrice { get;  }
        public short Quantity { get;  }

        public OrderDetail(int productId, decimal unitPrice, short quantity)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }
        public OrderDetail AddQuantity(short quantity) => new OrderDetail(ProductId, UnitPrice, (short)(Quantity + quantity));
    }
}
