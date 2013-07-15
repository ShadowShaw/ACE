using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Interfaces
{
    public interface IRepository<T, ID> where T : class, IEntity<ID> where ID : struct
    {
        IQueryable<T> GetAll();
        T GetByID(ID id);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
    }
}
