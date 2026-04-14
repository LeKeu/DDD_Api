using Common.Domain.ValueObjects;
using Common.Domain.ValueObjects.Order;
using Evento.Domain.Entities;

namespace Evento.Domain.Events
{
    public class OrderPaid : IDomainEvent
    {
        public ValueObject AggregateId { get; }
        public DateTime OccurredOn { get; }
        public int EventVersion { get; } = 1;

        public OrderPaid(
            OrderId_VO orderId,
            OrderStatus orderStatus
            )
        {
            OccurredOn = DateTime.UtcNow;
        }
    }
}
