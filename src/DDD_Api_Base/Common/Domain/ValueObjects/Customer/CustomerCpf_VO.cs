using Common.Domain.Exceptions;

namespace Common.Domain.ValueObjects.Customer
{
    public class CustomerCpf_VO : ValueObject<string>
    {
        public CustomerCpf_VO(string value) : base(value)
        {
            IsValid();
        }

        protected override bool IsValid()
        {
            if (Value.Length != 11)
                throw new InvalidCustomerException($"CPF tem {Value.Length} caracteres e deveria ter 11.");

            //if (!int.TryParse(Value.Replace(".", "").Replace("-", ""), out _))
            //    throw new InvalidCpfException("CPF deve ter apenas caracteres numéricos.");

            //alguma outra validação

            return true;
        }
    }
}
