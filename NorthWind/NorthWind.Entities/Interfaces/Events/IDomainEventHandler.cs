using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entities.Interfaces.Events
{
    public interface IDomainEventHandler<EventType> where EventType: IDomainEvent
    {
        void Handle(EventType eventTypeInstance);
    }
}
