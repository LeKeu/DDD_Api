using System.Text.Json;
using System.Xml.Linq;

namespace Domain.Entities
{
    public record CustomerConstructorProp()
    { // dessa forma, ao invés de eu ficar passando valores soltos no constructor, posso passar esse objeto
        public string? Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
    }

    public class Customer
    {
        string Id { get; set; }
        string Cpf { get; set; }
        string Nome { get; set; }

        public Customer(CustomerConstructorProp prop)
        {
            this.Id = prop.Id;
            this.Cpf = prop.Cpf;
            this.Nome = prop.Nome;
        }

        public static Customer CreateCustomer(CustomerConstructorProp prop)
        {
            return new Customer(prop);
        } // to seguindo como ele está fazendo na aula. discordo de como as coisas estão, mas vou continuar vendo para depois modificar melhor de acordo com o que eu aprendi
    
        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        public override string ToString()
        {
            return base.ToString();
            return $"{{ id: {Id}, cpf: {Cpf}, nome: {Nome} }}";
        }
    }

    

}
