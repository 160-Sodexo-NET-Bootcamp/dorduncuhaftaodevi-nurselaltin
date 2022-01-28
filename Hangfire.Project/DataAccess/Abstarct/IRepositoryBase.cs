using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAcces.Abstarct
{
    public interface IRepositoryBase<T> where T : class, IEntity, new()
    {
        Task Add(T entity, bool save);
        void Update(T entiy, bool save);
        void Delete(int ID, bool save);
        T GetByID(int ID);
        T Get(Expression<Func<T, bool>> filter = null);
        ICollection<T> GetAll(Expression<Func<T, bool>> filter = null);
    }
}
