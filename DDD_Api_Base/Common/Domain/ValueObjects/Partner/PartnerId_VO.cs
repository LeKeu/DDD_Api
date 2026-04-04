using Common.Domain.Exceptions;

namespace Common.Domain.ValueObjects.Partner
{
    public class PartnerId_VO : ValueObject<string>
    {
        public PartnerId_VO(string? id = null) : base(string.IsNullOrEmpty(id) ? Guid.NewGuid().ToString() : id)
        {
            IsValid();
        }

        protected override bool IsValid()
        {
            if (!Guid.TryParse(Value, out var uuid))
                throw new InvalidCustomerException($"Id {Value} do Partner deve ser UUID válido.");

            return true;
        }
    }
}
