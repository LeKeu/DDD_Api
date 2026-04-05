using Common.Domain;
using Common.Domain.ValueObjects.EventSection;
using System.Text.Json;

namespace Evento.Domain.Entities
{
    public class EventSection : Entity
    {
        public override object Id => _id;
        EventSectionId_VO _id { get; set; }
        string Name { get; set; }
        string? Description { get; set; }
        bool IsPublished { get; set; }
        int TotalSpots { get; set; }
        int TotalSpotsReserved { get; set; }
        decimal Price { get; set; }
        private List<EventSpot> _spots = new List<EventSpot>();

        public EventSection(EventSectionConstructorProps prop)
        {
            _id = prop.Id ?? new EventSectionId_VO();
            Name = prop.Name;
            Description = prop.Description;
            IsPublished = prop.IsPublished; 
            TotalSpots = prop.TotalSpots;
            TotalSpotsReserved = prop.TotalSpotsReserved;
            Price = prop.Price;
        }

        public static EventSection CreateEventSection(EventSectionCreateCommand command)
        {
            return new EventSection(new EventSectionConstructorProps(
                Id: null,
                Name: command.Name,
                Description: command.Description ?? null,
                IsPublished: false,
                TotalSpots: command.TotalSpots,
                TotalSpotsReserved: 0,
                Price: command.Price
                ));
        }

        public override string ToJson() => JsonSerializer.Serialize(this);
    }

    #region records
    public record EventSectionCreateCommand(
        string Name,
        string? Description,
        int TotalSpots,
        decimal Price
    );

    public record EventSectionConstructorProps(
        EventSectionId_VO Id,
        string Name,
        string? Description,
        bool IsPublished,
        int TotalSpots,
        int TotalSpotsReserved,
        decimal Price
    );
    #endregion
}
