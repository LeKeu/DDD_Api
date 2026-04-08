using Common.Domain;
using Common.Domain.ValueObjects.Event;
using Common.Domain.ValueObjects.Partner;
using System.Text.Json;

namespace Evento.Domain.Entities
{
    public class EventEntity : AggregateRoot
    {
        public override object Id => _id;
        EventId_VO _id ;
        string Name { get; set; }
        string? Descrption { get; set; }
        DateTime Date { get; set; }
        bool IsPublished { get; set; }
        int TotalSpots { get; set; }
        int TotalSpotsReserved { get; set; }
        PartnerId_VO PartnerId { get; set; }

        private List<EventSection> _section = new List<EventSection>();


        public EventEntity(EventConstructorProp prop)
        {
            _id = prop.Id ?? new EventId_VO();
            Name = prop.Name;
            Descrption = prop.Descritpion;
            Date = prop.Date;
            IsPublished = prop.IsPublished;
            TotalSpots = prop.TotalSpots;
            TotalSpotsReserved = prop.TotalSpotsReserved;
            PartnerId = prop.PartnerId ?? new PartnerId_VO();
        }

        public static EventEntity CreateEvent(CreateEventCommand command)
        {
            return new EventEntity(new EventConstructorProp(
                Id: null,
                Name: command.Name,
                Descritpion: command.Description,
                Date: command.Date,
                IsPublished: false,
                TotalSpots: 0,
                TotalSpotsReserved: 0,
                PartnerId: command.PartnerId
                ));
        }

        public override string ToJson() => JsonSerializer.Serialize(this);
    }

    #region Records
    public record CreateEventCommand(
        string Name,
        string? Description,
        DateTime Date,
        PartnerId_VO PartnerId
    );

    public record AddSectionCommand(
        string Name,
        string? Description,
        int TotalSpots,
        decimal Price
    );

    public record EventConstructorProp(
        EventId_VO? Id,
        string Name,
        string? Descritpion,
        DateTime Date,
        bool IsPublished,
        int TotalSpots,
        int TotalSpotsReserved,
        PartnerId_VO PartnerId
    );
    #endregion
}
