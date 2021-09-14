using Edura.WebUI.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Edura.WebUI.Repository.Concrete.EntityFramework
{
    public class EfGenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DbContext contex;
        public EfGenericRepository(DbContext dbContext)
        {
            contex = dbContext;
        }
        public void Add(T entity)
        {
            contex.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            contex.Set<T>().Remove(entity);
        }

        public void Edite(T entity)
        {
            contex.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
           return contex.Set<T>().Where(predicate);
        }

        public T Get(int id)
        {
            return contex.Set<T>().Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return contex.Set<T>();
        }

        public void Save()
        {
            contex.SaveChanges();
        }
    }
}
