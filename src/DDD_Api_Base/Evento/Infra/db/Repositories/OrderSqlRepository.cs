using Common.Domain.ValueObjects.Order;
using Common.Domain.ValueObjects.Partner;
using Evento.Domain.Entities;
using Evento.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Evento.Infra.db.Repositories
{
    public class OrderSqlRepository : IOrderSqlRepository
    {
        protected readonly DbContextSSMS _context;

        public OrderSqlRepository(DbContextSSMS context)
        {
            _context = context;
        }

        public async Task Add(OrderEntity entity)
        {
            await _context.Order.AddAsync(entity);
            _context.SaveChanges();
        }

        public async Task Delete(OrderEntity entity)
        {
            _context.Order.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<OrderEntity>> FindAll()
        {
            return await _context.Order.ToListAsync();
        }

        public async Task<OrderEntity> FindById(object Id)
        {
            if (Id is string stringId)
            {
                var orderId = new OrderId_VO(stringId);
                return await _context.Order.FindAsync(orderId);
            }
            else if (Id is OrderId_VO orderId)
            {
                return await _context.Order.FindAsync(orderId);
            }

            return null;
        }
    }
}
