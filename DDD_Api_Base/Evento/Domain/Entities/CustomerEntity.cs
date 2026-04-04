using Common.Domain.ValueObjects;
using System.Text.Json;
using Common.Domain;

namespace Evento.Domain.Entities
{

    public class Customer : AggregateRoot
    {
        public override object Id => _id;
        UuidVO _id { get; set; }
        public CpfVO Cpf { get; set; }
        public NomeVO Nome { get; set; }

        public Customer(CustomerConstructorProp prop)
        {
            _id = prop.Id ?? new UuidVO();
            Cpf = prop.Cpf;
            Nome = prop.Nome;
        }

        public static Customer CreateCustomer(CustomerConstructorProp prop)
        {
            return new Customer(prop);
        } // to seguindo como ele está fazendo na aula. discordo de como as coisas estão, mas vou continuar vendo para depois modificar melhor de acordo com o que eu aprendi

        public override string ToJson() //transformando em override por causa da classe mãe!
        {
            return JsonSerializer.Serialize(this);
        }

        public override string ToString()
        {
            return base.ToString();
            //return $"{{ id: {Id}, cpf: {Cpf}, nome: {Nome} }}";
        }
    }

    public record CustomerConstructorProp()
    { // dessa forma, ao invés de eu ficar passando valores soltos no constructor, posso passar esse objeto
        public UuidVO? Id { get; set; }
        public CpfVO Cpf { get; set; }
        public NomeVO Nome { get; set; }
    }

}
