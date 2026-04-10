using Common.Domain;
namespace Evento.Domain.Repositories
{
    public interface IRepository<E> where E : AggregateRoot
    {//mano eu adorei isso aqui
        Task Add(E entity);
        Task<E> FindById(object Id);
        Task<List<E>> FindAll();
        Task Delete(E entity);
    }
}
