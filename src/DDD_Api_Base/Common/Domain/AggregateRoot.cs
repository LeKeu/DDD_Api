using Evento.Domain;

namespace Common.Domain
{
    // tbm é um entity, ent pode herdar de entity. mas abstract pq ele n vai precisar fazer override de nada
    public abstract class AggregateRoot : Entity
    {
        private List<IDomainEvent> _events = new List<IDomainEvent>();
        protected void AddEvent(IDomainEvent domainEvent) => _events.Add(domainEvent);

        protected void ClearEvents() => _events.Clear();
    }
}
