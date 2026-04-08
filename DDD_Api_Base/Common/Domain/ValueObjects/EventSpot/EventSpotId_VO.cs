using Common.Domain.Exceptions;

namespace Common.Domain.ValueObjects.EventSpot
{
    public class EventSpotId_VO : ValueObject<string>
    {
        public EventSpotId_VO(string? id = null) : base(string.IsNullOrEmpty(id) ? Guid.NewGuid().ToString() : id)
        {
            IsValid();
        }

        protected override bool IsValid()
        {
            if (!Guid.TryParse(Value, out var uuid))
                throw new InvalidEventSpotException($"Id {Value} do EventSpot deve ser UUID válido.");

            return true;
        }
    }
}
