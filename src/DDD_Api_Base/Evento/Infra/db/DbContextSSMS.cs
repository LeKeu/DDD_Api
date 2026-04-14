using Evento.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Evento.Infra.db
{
    public class DbContextSSMS : DbContext
    {
        public DbContextSSMS(DbContextOptions<DbContextSSMS> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<EventEntity> EventEntity { get; set; }
        public DbSet<Partner> Partner { get; set; }
        public DbSet<OrderEntity> Order { get; set; }
        //restinho

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ver se precisa adicionar alguma coisa aqui
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbContextSSMS).Assembly);
        }
    }
}
