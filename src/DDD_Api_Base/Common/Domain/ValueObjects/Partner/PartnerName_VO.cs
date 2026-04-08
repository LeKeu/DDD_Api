using Common.Domain.Exceptions;

namespace Common.Domain.ValueObjects.Partner
{
    public class PartnerName_VO : ValueObject<string>
    {
        public PartnerName_VO(string nome) : base(nome) 
        {
            IsValid();
        }

        protected override bool IsValid()
        {
            if (Value.Length <= 3) // esse 'Value' pega o que foi passado no base()
                throw new InvalidPartnerException("Nome do Partner deve ter mais do que 3 caracteres.");

            // quaisquer outras validações no futuro
            return true;
        }
    }
}
