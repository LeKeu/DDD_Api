using Common.Domain.Exceptions;

namespace Common.Domain.ValueObjects.Order
{
    public class OrderId_VO : ValueObject<string>
    {
        public OrderId_VO(string? id = null) : base(string.IsNullOrEmpty(id) ? Guid.NewGuid().ToString() : id)
        {
            IsValid();
        }

        protected override bool IsValid()
        {
            if (!Guid.TryParse(Value, out var uuid))
                throw new InvalidOrderException($"Id {Value} do Order deve ser UUID válido.");

            return true;
        }
    }
}
