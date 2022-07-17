using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entities.Interfaces.Events
{
    public interface IDomainEventHub<EventType>
        where EventType : IDomainEvent
    {
        void Raise(EventType eventTypeInstance);

    }
}
