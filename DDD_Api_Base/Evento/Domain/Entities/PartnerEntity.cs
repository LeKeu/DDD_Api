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
            Name = prop.Name;
        }

        public Partner CreatePartner(PartnerConstructoProps prop)
        {
            return new Partner(prop);
        }

        public void ChangeName(string name)
        {
            this.Name = new PartnerName_VO(name);
        }

        public override string ToJson() => JsonSerializer.Serialize(this);
    }
    public record PartnerConstructoProps
    {
        public PartnerId_VO? Id { get; set; }
        public PartnerName_VO Name { get; set; }
    }
}
