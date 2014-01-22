using System.Linq;

namespace Core.Interfaces
{
    public interface IRepository<T, in TID> where T : class, IEntity<TID> where TID : struct
    {
        IQueryable<T> GetAll();
        T GetByID(TID id);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
    }
}
