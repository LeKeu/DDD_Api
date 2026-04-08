using Common.Domain;
using Common.Domain.ValueObjects.Partner;
using System.Text.Json;

namespace Evento.Domain.Entities
{

    public class Partner : AggregateRoot
    {
        public override object Id => _id;
        PartnerId_VO _id { get; set; }
        PartnerName_VO Name { get; set; }


        public Partner(PartnerConstructoProps prop)
        {
            _id = prop.Id ?? new PartnerId_VO();
            Name = prop.Nome;
        }

        public Partner CreatePartner(PartnerCreateCommand command)
        {
            return new Partner(new PartnerConstructoProps(Id: null, Nome: command.Nome));
        }

        public void ChangeName(string name)
        {
            this.Name = new PartnerName_VO(name);
        }

        public override string ToJson() => JsonSerializer.Serialize(this);

        public EventEntity InitEvent(InitEventCommand command)
        {
            return EventEntity.CreateEvent( 
                new CreateEventCommand(
                    Name: command.Nome, 
                    Description: command.Description,
                    Date: command.date,
                    PartnerId: this._id
                ));
        }
    }

    #region records

    public record PartnerCreateCommand(
        PartnerName_VO Nome
        );

    public record PartnerConstructoProps(
        PartnerId_VO? Id,
        PartnerName_VO Nome
        );

    public record InitEventCommand(
        string Nome,
        string? Description, 
        DateTime date
        );
    #endregion
}
