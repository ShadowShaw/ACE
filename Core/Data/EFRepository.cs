using System.Linq;
using Core.Interfaces;

namespace Core.Data
{
    public class EFRepository<T> : IRepository<T, int> where T : class, IEntity<int>
    {
        private readonly UnitOfWork unitOfWork;
        
        public EFRepository(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public virtual IQueryable<T> GetAll()
        {
            IQueryable<T> query = unitOfWork.EfContext.Set<T>(); //.AsNoTracking();
            //IQueryable<T> query = this.unitOfWork.EfContext.ObjectSetAsNoTracking<T>();
            return query;
        }
        
        public virtual T GetByID(int id)
        {
            return GetAll().FirstOrDefault(t => t.Id.Equals(id));
        }

        public virtual void Add(T entity)
        {            
            unitOfWork.EfContext.Set<T>().Add(entity);
            //entity = entity.Clone();
        }

        public virtual void Delete(T entity)
        {
            unitOfWork.EfContext.Set<T>().Attach(entity);
            unitOfWork.EfContext.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            unitOfWork.EfContext.Set<T>().Attach(entity);
            
            unitOfWork.EfContext.Entry(entity).State = System.Data.EntityState.Modified;
            //entity = entity.Clone();
        }
    }
}
    