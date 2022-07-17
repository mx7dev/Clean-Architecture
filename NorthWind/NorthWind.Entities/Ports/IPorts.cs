using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entities.Ports
{
    public interface IPorts<T>
    {
        ValueTask Handle(T dto);
    }
    public interface IPort
    {
        ValueTask Handle();
    }
}
