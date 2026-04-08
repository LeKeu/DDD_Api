using Common.Domain;
using Common.Domain.ValueObjects.Event;
using Common.Domain.ValueObjects.Partner;
using Evento.Domain.Events;
using System.Text.Json;

namespace Evento.Domain.Entities
{
    public class EventEntity : AggregateRoot
    {
        public override object Id => _id;
        EventId_VO _id {  get; set; }
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

        public EventEntity CreateEvent(CreateEventCommand command)
        {
            var eventCreated = new EventEntity(new EventConstructorProp(
                Id: null,
                Name: command.Name,
                Descritpion: command.Description,
                Date: command.Date,
                IsPublished: false,
                TotalSpots: 0,
                TotalSpotsReserved: 0,
                PartnerId: command.PartnerId
                ));
            
            AddEvent(
                new EventCreated(
                    eventCreated._id,
                    eventCreated.Name,
                    eventCreated.Descrption,
                    eventCreated.Date,
                    eventCreated.IsPublished,
                    eventCreated.TotalSpots,
                    eventCreated.TotalSpotsReserved,
                    eventCreated.PartnerId
                    ));

            return eventCreated;
        }

        public override string ToJson() => JsonSerializer.Serialize(this);

        public void AddSection(AddSectionCommand command)
        {
            var section = EventSection.CreateEventSection(new EventSectionCreateCommand(command.Name, command.Description, command.TotalSpots, command.Price));
            _section.Add(section);
            this.TotalSpots += section.TotalSpots;
            AddEvent(
                new EventAddedSection(
                    this._id, section.Name, 
                    section.Description, section.TotalSpots, 
                    section.Price, this.TotalSpots));
        }

        #region changes
        public void ChangeName(string newName) => this.Name = newName;
        public void ChangeDescription(string newDescription) => this.Descrption = newDescription;
        public void ChangeDate(DateTime newDate) => this.Date = newDate;
        #endregion

        #region publish
        private void Publish()
        {
            this.IsPublished = true;
            this.AddEvent(new EventPublish(this._id));
        }

        private void UnPublish()
        {
            this.IsPublished = false;
            this.AddEvent(new EventUnpublish(this._id));
        }

        private void PublishAll()
        {
            Publish();
            _section.ForEach(x => x.PublishAll());
            AddEvent(new EventPublishAll(this._id, _section.Select(x => x.Id).ToArray()));
        }
        #endregion
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
