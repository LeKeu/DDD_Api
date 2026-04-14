using Common.Domain;
using Common.Domain.ValueObjects.Customer;
using Common.Domain.ValueObjects.EventSpot;
using System.Text.Json;

namespace Evento.Domain.Entities
{
    public class SpotReservationEntity : AggregateRoot
    {
        public override object Id => _id;
        EventSpotId_VO _id {  get; set; }
        DateTime ReservationDate { get; set; }
        CustomerId_VO _customerId { get; set; }

        public SpotReservationEntity(SpotReservationConstructorProps prop)
        {
            _id = prop.eventSpotId  ?? new EventSpotId_VO();
            ReservationDate = prop.reservationDate;
            _customerId = prop.customerId ?? new CustomerId_VO();
        }

        public SpotReservationEntity CreateSpotReservation(SpotReservationCreateCommand command)
        {
            var reservation = new SpotReservationEntity(
                new SpotReservationConstructorProps(command.eventSpotId, DateTime.UtcNow, command.customerId));
            reservation.AddEvent();
        }

        public override string ToJson() => JsonSerializer.Serialize(this);
    }

    #region records
    public record SpotReservationCreateCommand(
        EventSpotId_VO eventSpotId,
        CustomerId_VO customerId
        );

    public record SpotReservationConstructorProps(
        EventSpotId_VO eventSpotId,
        DateTime reservationDate,
        CustomerId_VO customerId
        );
    #endregion
}
