using Common.Domain.ValueObjects;
using Common.Domain.ValueObjects.Event;

namespace Evento.Domain.Events
{
    public class EventUnpublish : IDomainEvent
    {
        public ValueObject AggregateId { get; }
        public DateTime OccurredOn { get; }
        public int EventVersion { get; } = 1;

        private readonly bool isPublished = false;


        public EventUnpublish(EventId_VO aggregateId)
        {
            OccurredOn = DateTime.UtcNow;
        }
    }
}
