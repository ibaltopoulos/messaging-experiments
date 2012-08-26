using System;

namespace model.events
{
    interface IEvent
    {
        Guid EventId { get; set; }
    }
}