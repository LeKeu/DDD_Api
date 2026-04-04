using Common.Domain.Exceptions;

namespace Common.Domain.ValueObjects.Customer
{
    public class CustomerName_VO : ValueObject<string>
    {
        //depois gerar o teste dele no proj de teste!! só preciso resolver o bo do teste
        public CustomerName_VO(string nome) : base(nome)
        {
            IsValid();
        }

        protected override bool IsValid()
        { // faço minhas validações internas do nome, o que eu quiser
            if (Value.Length <= 3) // esse 'Value' pega o que foi passado no base()
                throw new InvalidCustomerException("Nome precisa ter mais do que 3 caracteres.");

            // quaisquer outras validações no futuro

            return true;
        }
    }
}
