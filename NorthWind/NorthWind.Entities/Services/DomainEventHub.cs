using NorthWind.Entities.Interfaces.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entities.Services
{
    public class DomainEventHub<EventType> : IDomainEventHub<EventType>
        where EventType : IDomainEvent
    {
        readonly IEnumerable<IDomainEventHandler<EventType>> EventHandlers;

        public DomainEventHub(IEnumerable<IDomainEventHandler<EventType>> eventHandlers)
        {
            EventHandlers = eventHandlers;
        }
        public void Raise(EventType eventTypeInstance)
        {
            foreach (var Handler in EventHandlers)
            {
                Task.Run(()=> Handler.Handle(eventTypeInstance));

            }
        }
    }
}
