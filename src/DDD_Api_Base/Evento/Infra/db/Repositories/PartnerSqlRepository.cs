using Common.Domain.ValueObjects.Customer;
using Common.Domain.ValueObjects.Partner;
using Evento.Domain.Entities;
using Evento.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Evento.Infra.db.Repositories
{
    public class PartnerSqlRepository : IPartnerSqlRepository
    {
        protected readonly DbContextSSMS _context;

        public PartnerSqlRepository(DbContextSSMS context)
        {
            _context = context;
        }

        public async Task Add(Partner entity)
        {
            await _context.Partner.AddAsync(entity);
            _context.SaveChanges();
        }

        public async Task Delete(Partner entity)
        {
            _context.Partner.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Partner>> FindAll()
        {
            return await _context.Partner.ToListAsync();
        }

        public async Task<Partner> FindById(object Id)
        {
            if (Id is string stringId)
            {
                var partnerId = new PartnerId_VO(stringId);
                return await _context.Partner.FindAsync(partnerId);
            }
            else if (Id is PartnerId_VO partnerId)
            {
                return await _context.Partner.FindAsync(partnerId);
            }

            return null;
        }
    }
}
