using DataAcces.Abstarct;
using Entity.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAcces.Concrete
{
    public class EfRepostioryBase<T, TContext> : IRepositoryBase<T> where T : class, IEntity, new()
        where TContext: DbContext, new()
    {

        /// <summary>
        /// The save parameter gets for unity of work design's Save Changes method in Add-Update-Delete methods.
        /// If you aren't save changes, these methods save changes. Thus ,You don't need save changes into unity of work class.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="save"></param>
        public virtual async Task  Add(T entity, bool save = true)
        {
            using (TContext _context = new TContext())
            {
               await _context.Set<T>().AddAsync(entity);
                if (save) await _context.SaveChangesAsync();
            } 
        }
        public virtual void Delete(int ID, bool save = true)
        {
            using (TContext _context = new TContext())
            {
                _context.Set<T>().Remove(GetByID(ID));
                if (save) _context.SaveChanges();
            }
         
        }
        public T Get(Expression<Func<T, bool>> filter = null)
        {
            using (TContext _context = new TContext())
            {
                return _context.Set<T>().FirstOrDefault(filter);
            }
           
        }
        public virtual ICollection<T> GetAll(Expression<Func<T,bool>> filter = null)
        {
            using (TContext _context = new TContext())
            {
                if (filter == null)
                {
                  return  _context.Set<T>().ToList();
                }
                else
                {
                   return _context.Set<T>().Where(filter).ToList(); ;
                }
            }
        }
           
        public virtual T GetByID(int ID)
        {
            using (TContext _context = new TContext())
            {
                return _context.Set<T>().Find(ID);
            }
           
        }
        public virtual void Update(T entity, bool save = true)
        {
            using (TContext _context = new TContext())
            {
                 _context.Update(entity);
                if (save) _context.SaveChanges();
            }
          
        }
    }
}
