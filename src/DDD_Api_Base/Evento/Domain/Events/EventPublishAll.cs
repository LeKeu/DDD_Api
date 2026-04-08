using Common.Domain.ValueObjects;
using Common.Domain.ValueObjects.Event;
using Common.Domain.ValueObjects.EventSection;

namespace Evento.Domain.Events
{
    public class EventPublishAll : IDomainEvent
    {
        public ValueObject AggregateId { get; }
        public DateTime OccurredOn { get; }
        public int EventVersion { get; } = 1;

        public EventPublishAll(EventId_VO aggregate_id, object[] sectionsId) // EventSectionId_VO[] sectionsId
        {
            OccurredOn = DateTime.UtcNow;
        }
    }
}
