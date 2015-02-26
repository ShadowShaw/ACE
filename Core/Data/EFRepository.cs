using System.Linq;
using Core.Interfaces;

namespace Core.Data
{
    public class EfRepository<T> : IRepository<T, int> where T : class, IEntity<int>
    {
        private readonly UnitOfWork _unitOfWork;
        
        public EfRepository(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public virtual IQueryable<T> GetAll()
        {
            IQueryable<T> query = _unitOfWork.EfContext.Set<T>(); //.AsNoTracking();
            //IQueryable<T> query = this.unitOfWork.EfContext.ObjectSetAsNoTracking<T>();
            return query;
        }
        
        public virtual T GetByID(int id)
        {
            return GetAll().FirstOrDefault(t => t.Id.Equals(id));
        }

        public virtual void Add(T entity)
        {            
            _unitOfWork.EfContext.Set<T>().Add(entity);
            //entity = entity.Clone();
        }

        public virtual void Delete(T entity)
        {
            _unitOfWork.EfContext.Set<T>().Attach(entity);
            _unitOfWork.EfContext.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            _unitOfWork.EfContext.Set<T>().Attach(entity);
            
            _unitOfWork.EfContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            //entity = entity.Clone();
        }
    }
}
    