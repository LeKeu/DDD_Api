using Common.Domain.ValueObjects;
using Common.Domain.ValueObjects.Customer;
using Common.Domain.ValueObjects.EventSpot;
using Common.Domain.ValueObjects.Order;
using Evento.Domain.Entities;

namespace Evento.Domain.Events
{
    public class OrderCreated : IDomainEvent
    {
        public ValueObject AggregateId { get; }
        public DateTime OccurredOn { get; }
        public int EventVersion { get; } = 1;

        public OrderCreated(
            OrderId_VO orderId,
            CustomerId_VO customerId,
            decimal amount,
            EventSpotId_VO eventSpotId,
            OrderStatus orderStatus
            )
        {
            OccurredOn = DateTime.UtcNow;
        }
    }
}
