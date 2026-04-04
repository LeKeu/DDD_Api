using Common.Domain;
using System.Text.Json;

namespace DDD_Api_Base.Evento.Domain.Entities
{

    public class Customer : AggregateRoot
    {
        string Id { get; set; }
        string Cpf { get; set; }
        string Nome { get; set; }

        public Customer(CustomerConstructorProp prop)
        {
            Id = prop.Id;
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
            return $"{{ id: {Id}, cpf: {Cpf}, nome: {Nome} }}";
        }
    }

    public record CustomerConstructorProp()
    { // dessa forma, ao invés de eu ficar passando valores soltos no constructor, posso passar esse objeto
        public string? Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
    }

}
