using Common.Domain;
using Common.Domain.ValueObjects.EventSection;
using System.Text.Json;

namespace Evento.Domain.Entities
{
    public class EventSection : Entity
    {
        public override object Id => _id;
        EventSectionId_VO _id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsPublished { get; set; }
        public int TotalSpots { get; set; }
        public int TotalSpotsReserved { get; set; }
        public decimal Price { get; set; }
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

        #region Changes
        public void ChangeName(string newName) => this.Name = newName;
        public void ChangeDescription(string newDescription) => this.Description = newDescription;
        public void ChangePrice(decimal newPrice) => this.Price = newPrice;
        public void ChangeLocation(string newLocation)
        {
            // AQUI
        }

        #endregion

        #region publish
        public void Publish() => IsPublished = true;
        public void UnPublish() => IsPublished = false;
        public void PublishAll()
        {
            this.Publish();
            _spots.ForEach(x => x.Publish());
        }
        #endregion
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
