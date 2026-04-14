using Common.Domain;
using System.Text.Json;
using Common.Domain.ValueObjects.EventSpot;

namespace Evento.Domain.Entities
{
    public class EventSpot : Entity
    {
        public override object Id => _id;
        public EventSpotId_VO _id {  get; set; }
        public string Location { get; set; }
        public bool IsReserved { get; set; }
        public bool IsPublished { get; set; }

        public EventSpot(EventSpotConstructorProps prop)
        {
            _id = prop.Id ?? new EventSpotId_VO();
            Location = prop.Location;
            IsReserved = prop.IsReserved;
            IsPublished = prop.IsPublished;
        }

        public static EventSpot CreateEventSpot()
        {
            return new EventSpot(
                new EventSpotConstructorProps(Id: null, Location: null, IsReserved: false, IsPublished: false));
        }

        public void ChangeLocation(string newLocation)
        {
           Location = newLocation;
        }

        public override string ToJson() => JsonSerializer.Serialize(this);

        #region publish
        public void Publish() => IsPublished = true;
        public void UnPublish() => IsPublished = false;
        public void MarkAsReserved() => IsReserved = true;
        #endregion
    }

    #region records
    public record EventSpotConstructorProps(
        EventSpotId_VO? Id,
        string? Location,
        bool IsReserved,
        bool IsPublished
        );
    #endregion
}
