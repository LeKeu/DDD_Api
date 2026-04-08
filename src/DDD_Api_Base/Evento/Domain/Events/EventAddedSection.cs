using Common.Domain.ValueObjects;
using Common.Domain.ValueObjects.Event;

namespace Evento.Domain.Events
{
    public class EventAddedSection : IDomainEvent
    {
        public ValueObject AggregateId { get; }
        public DateTime OccurredOn { get; }
        public int EventVersion { get; } = 1;

        public EventAddedSection(
            EventId_VO aggregate_id, 
            string sectionName, 
            string? sectionDecription,
            int sectionTotalSpots,
            decimal sectionPrice, 
            decimal eventTotalSpots
            )
        {
            OccurredOn = DateTime.UtcNow;
        }
    }
}
