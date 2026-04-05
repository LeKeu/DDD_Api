using Common.Domain.Exceptions;

namespace Common.Domain.ValueObjects.EventSection
{
    public class EventSectionId_VO : ValueObject<string>
    {
        public EventSectionId_VO(string? id = null) : base(string.IsNullOrEmpty(id) ? Guid.NewGuid().ToString() : id)
        {
            IsValid();
        }

        protected override bool IsValid()
        {
            if (!Guid.TryParse(Value, out var uuid))
                throw new InvalidEventSectionException($"Id {Value} do EventSection deve ser UUID válido.");

            return true;
        }
    }
}
