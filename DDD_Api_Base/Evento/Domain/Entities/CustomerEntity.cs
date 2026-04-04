using System.Text.Json;
using Common.Domain;
using Common.Domain.ValueObjects.Customer;

namespace Evento.Domain.Entities
{

    public class Customer : AggregateRoot
    {
        public override object Id => _id;
        CustomerId_VO _id { get; set; }
        public CustomerCpf_VO Cpf { get; set; }
        public CustomerName_VO Name { get; set; }

        public Customer(CustomerConstructorProp prop)
        {
            _id = prop.Id ?? new CustomerId_VO();
            Cpf = prop.Cpf;
            Name = prop.Name;
        }

        public static Customer CreateCustomer(CustomerConstructorProp prop)
        {
            return new Customer(prop);
        } // to seguindo como ele está fazendo na aula. discordo de como as coisas estão, mas vou continuar vendo para depois modificar melhor de acordo com o que eu aprendi

        public void ChangeName(string nome)
        {
            this.Name = new CustomerName_VO(nome);
        }

        public override string ToJson() => JsonSerializer.Serialize(this);

        public override string ToString()
        {
            return base.ToString();
            //return $"{{ id: {Id}, cpf: {Cpf}, nome: {Nome} }}";
        }
    }

    public record CustomerConstructorProp()
    { // dessa forma, ao invés de eu ficar passando valores soltos no constructor, posso passar esse objeto
        public CustomerId_VO? Id { get; set; }
        public CustomerCpf_VO Cpf { get; set; }
        public CustomerName_VO Name { get; set; }
    }

}
