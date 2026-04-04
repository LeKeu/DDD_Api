using Common.Domain.Exceptions;

namespace Common.Domain.ValueObjects
{
    public class UuidVO : ValueObject<string>
    {
        public UuidVO(string? id = null) : base(string.IsNullOrEmpty(id) ? Guid.NewGuid().ToString() : id)
        {
            IsValid();
        }

        protected override bool IsValid()
        {
            if (!Guid.TryParse(Value, out var uuid))
                throw new InvalidUuidException($"Id {Value} deve ser UUID válido.");

            return true;
        }
    }
}
