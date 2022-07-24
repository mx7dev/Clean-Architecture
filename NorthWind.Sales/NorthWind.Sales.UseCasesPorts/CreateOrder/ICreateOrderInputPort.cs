using NorthWind.Sales.DTOs.CreateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NorthWind.Entities.Interfaces;
namespace NorthWind.Sales.UseCasesPorts.CreateOrder
{
    public interface ICreateOrderInputPort: IPort<CreateOrderDTO>
    {

    }
}
