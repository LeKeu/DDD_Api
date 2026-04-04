using Common.Domain.Exceptions;

namespace Common.Domain.ValueObjects
{
    public class CpfVO : ValueObject<string>
    {
        public CpfVO(string value) : base(value)
        {
            IsValid();
        }

        protected override bool IsValid()
        {
            if (Value.Length != 11)
                throw new InvalidCpfException($"CPF tem {Value.Length} caracteres e deveria ter 11.");

            //if (!int.TryParse(Value.Replace(".", "").Replace("-", ""), out _))
            //    throw new InvalidCpfException("CPF deve ter apenas caracteres numéricos.");
            
            //alguma outra validação

            return true;
        }
    }
}
