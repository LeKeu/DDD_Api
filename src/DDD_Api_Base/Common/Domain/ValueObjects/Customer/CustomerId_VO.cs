using Common.Domain.Exceptions;

namespace Common.Domain.ValueObjects.Customer
{
    public class CustomerId_VO : ValueObject<string>
    {
        public CustomerId_VO(string? id = null) : base(string.IsNullOrEmpty(id) ? Guid.NewGuid().ToString() : id)
        {
            IsValid();
        }

        protected override bool IsValid()
        {
            if (!Guid.TryParse(Value, out var uuid))
                throw new InvalidCustomerException($"Id {Value} deve ser UUID válido.");

            return true;
        }
    }
}
