using Common.Domain.ValueObjects;
using Common.Domain.ValueObjects.Event;

namespace Evento.Domain.Events
{
    public class EventPublish : IDomainEvent
    {
        public ValueObject AggregateId { get; }
        public DateTime OccurredOn { get; }
        public int EventVersion { get; } = 1;

        private readonly bool isPublished = true;

        public EventPublish(EventId_VO aggregateId)
        {
            OccurredOn = DateTime.UtcNow;
        }
    }
}
