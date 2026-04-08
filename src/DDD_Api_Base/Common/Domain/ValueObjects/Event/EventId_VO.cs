using Common.Domain.Exceptions;

namespace Common.Domain.ValueObjects.Event
{
    public class EventId_VO : ValueObject<string>
    {
        public EventId_VO(string? id = null) : base(string.IsNullOrEmpty(id) ? Guid.NewGuid().ToString() : id)
        {
            IsValid();
        }

        protected override bool IsValid()
        {
            if (!Guid.TryParse(Value, out var uuid))
                throw new InvalidEventException($"Id {Value} do Event deve ser UUID válido.");

            return true;
        }
    }
}
