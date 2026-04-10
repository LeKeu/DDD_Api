using Evento.Domain.Entities;
using Evento.Domain.Repositories;
using Evento.Infra.db.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Evento.Infra.db
{
    public static class DbContextFactory
    {
        public static void AddDbContextFactory(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<DbContextSSMS>(options =>
                options.UseSqlServer(connectionString));
            
            //repositories
            services.AddScoped<IRepository<Customer>, CustomerSqlRepository>();
        }
    }
}
