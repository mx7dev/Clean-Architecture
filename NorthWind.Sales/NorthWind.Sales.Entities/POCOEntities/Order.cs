using NorthWind.Sales.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sales.Entities.POCOEntities
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
        public string ShipPostalCode { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;
        public DiscountType DiscountType { get; set; } = DiscountType.Percentage;
        public double Discount { get; set; } = 10;
        public ShippingType ShippingType { get; set; } = ShippingType.Road;
    }
}
