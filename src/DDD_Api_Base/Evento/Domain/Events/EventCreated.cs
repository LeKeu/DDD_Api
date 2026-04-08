using Common.Domain.ValueObjects;
using Common.Domain.ValueObjects.Event;
using Common.Domain.ValueObjects.Partner;

namespace Evento.Domain.Events
{
    public class EventCreated : IDomainEvent
    {
        public ValueObject AggregateId { get; }
        public DateTime OccurredOn { get; }
        public int EventVersion { get; } = 1;

        public EventCreated(
            EventId_VO aggregate_id,
            string name,
            string description,
            DateTime date,
            bool isPublished,
            int totalSpots,
            int totalSpotsReserved,
            PartnerId_VO partnerId
            )
        {
            OccurredOn = DateTime.UtcNow;
        }
    }
}
