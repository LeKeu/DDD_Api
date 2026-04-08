using Common.Domain.ValueObjects;

namespace Evento.Domain
{
    public interface IDomainEvent
    {// normalmente eu coloco interfaces em uma pasta separada, como Ports ou Interfaces
        ValueObject AggregateId { get; } // identificar como ter uma var do valueobject!
        DateTime OccurredOn { get; }
        int EventVersion {  get; }
    }
}
