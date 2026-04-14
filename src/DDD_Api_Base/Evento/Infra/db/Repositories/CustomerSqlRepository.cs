using Common.Domain.ValueObjects.Customer;
using Evento.Domain.Entities;
using Evento.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Evento.Infra.db.Repositories
{
    public class CustomerSqlRepository : ICustomerSqlRepository
    {
        private readonly DbContextSSMS _context;

        public CustomerSqlRepository(DbContextSSMS context)
        {
            _context = context;
        }

        public async Task Add(Customer entity)
        {
            await _context.Customers.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Customer entity)
        {
            _context.Customers.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Customer>> FindAll()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> FindById(object Id)
        {
            if (Id is string stringId)
            {
                var customerId = new CustomerId_VO(stringId);
                return await _context.Customers.FindAsync(customerId);
            }
            else if (Id is CustomerId_VO customerId)
            {
                return await _context.Customers.FindAsync(customerId);
            }

            return null;
        }
    }
}
