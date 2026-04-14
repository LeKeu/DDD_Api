using Common.Domain;
using Common.Domain.ValueObjects.Customer;
using Common.Domain.ValueObjects.EventSpot;
using Common.Domain.ValueObjects.Order;
using Evento.Domain.Events;
using System.Text.Json;

namespace Evento.Domain.Entities
{
    public class OrderEntity : AggregateRoot
    {
        public override object Id => _id;
        OrderId_VO _id {  get; set; }
        public CustomerId_VO CustmerId { get; set; }
        public decimal Amount { get; set; }
        public EventSpotId_VO EventSpotId { get; set; }
        public OrderStatus orderStatus { get; set; } = OrderStatus.PENDING;

        public OrderEntity(OrderConstructorProp prop)
        {
            this._id = prop.Id ?? new OrderId_VO();
            CustmerId = prop.CustomerId ?? new CustomerId_VO();
            Amount = prop.Amount;
            EventSpotId = prop.EventSpotId ?? new EventSpotId_VO();
        }

        public OrderEntity CreateOrder(OrderConstructorProp prop)
        {
            var order = new OrderEntity(prop);
            order.AddEvent(
                new OrderCreated(prop.Id, prop.CustomerId, prop.Amount, 
                prop.EventSpotId, prop.orderStatus));
            
            return order;
        }

        public void Pagar()
        {
            this.orderStatus = OrderStatus.PAID;
            AddEvent(new OrderPaid(this._id, this.orderStatus));
        }

        public void Cancelar()
        {
            this.orderStatus = OrderStatus.CANCELLED;
            AddEvent(new OrderCancelled(this._id, this.orderStatus));
        }

        public override string ToJson() => JsonSerializer.Serialize(this);
    }

    #region record
    public record OrderConstructorProp(
        OrderId_VO? Id,
        CustomerId_VO CustomerId, 
        decimal Amount, 
        EventSpotId_VO EventSpotId,
        OrderStatus orderStatus
        );

    public enum OrderStatus
    {
        PENDING,
        PAID, 
        CANCELLED
    }
    #endregion
}
