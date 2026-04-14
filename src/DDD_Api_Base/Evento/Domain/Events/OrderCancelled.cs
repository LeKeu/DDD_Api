using Common.Domain.ValueObjects;
using Common.Domain.ValueObjects.Customer;
using Common.Domain.ValueObjects.EventSpot;
using Common.Domain.ValueObjects.Order;
using Evento.Domain.Entities;

namespace Evento.Domain.Events
{
    public class OrderCancelled : IDomainEvent
    {
        public ValueObject AggregateId { get; }
        public DateTime OccurredOn { get; }
        public int EventVersion { get; } = 1;

        public OrderCancelled(
            OrderId_VO orderId,
            OrderStatus orderStatus
            )
        {
            OccurredOn = DateTime.UtcNow;
        }
    }
}
