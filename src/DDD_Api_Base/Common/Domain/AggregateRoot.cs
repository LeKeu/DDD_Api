using Evento.Domain;

namespace Common.Domain
{
    // tbm é um entity, ent pode herdar de entity. mas abstract pq ele n vai precisar fazer override de nada
    public abstract class AggregateRoot : Entity
    {
        List<IDomainEvent> events = new List<IDomainEvent>();
        protected void AddEvent(IDomainEvent domainEvent) => events.Add(domainEvent);

        protected void ClearEvents() => events.Clear();
    }
}
