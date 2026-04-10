using Common.Domain;
using Common.Domain.ValueObjects.Customer;
using Common.Domain.ValueObjects.EventSpot;
using Common.Domain.ValueObjects.Order;
using System.Text.Json;

namespace Evento.Domain.Entities
{
    public class OrderEntity : AggregateRoot
    {
        public override object Id => _id;
        OrderId_VO _id {  get; set; }

        public override string ToJson() => JsonSerializer.Serialize(this);
    }

    #region record
    public record OrderConstructorProp(
        OrderId_VO? Id,
        CustomerId_VO CustomerId, 
        decimal Amount, 
        EventSpotId_VO EventSpotId
        );

    enum OrderStatus
    {
        PENDING,
        PAID, 
        CANCELLED
    }
    #endregion
}
