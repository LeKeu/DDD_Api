using Common.Domain.ValueObjects.Event;
using Evento.Domain.Entities;
using Evento.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Evento.Infra.db.Repositories
{
    public class EventEntitySqlRepository : IEventEntitySqlRepository
    {
        protected readonly DbContextSSMS _context;

        public EventEntitySqlRepository(DbContextSSMS context)
        {
            _context = context;
        }

        public async Task Add(EventEntity entity)
        {
            await _context.EventEntity.AddAsync(entity);
            _context.SaveChanges();
        }

        public async Task Delete(EventEntity entity)
        {
            _context.EventEntity.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<EventEntity>> FindAll()
        {
            return await _context.EventEntity.ToListAsync();
        }

        public async Task<EventEntity> FindById(object Id)
        {
            if (Id is string stringId)
            {
                var eventEntityId = new EventId_VO(stringId);
                return await _context.EventEntity.FindAsync(eventEntityId);
            }
            else if (Id is EventId_VO eventEntityId)
            {
                return await _context.EventEntity.FindAsync(eventEntityId);
            }

            return null;
        }
    }
}
