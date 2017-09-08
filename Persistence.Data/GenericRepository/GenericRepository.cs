using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public GenericRepository(DbContext context)
        {
            Context = context;
        }
        public TEntity Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            return entity;
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            var list = Context.Set<TEntity>().ToList();
            return list;
        }

        public IEnumerable<TEntity> Include(List<string> includes)
        {
            IEnumerable<TEntity> query = null;
            foreach (var include in includes)
            {
                query = Context.Set<TEntity>().Include((include.ToString()));
            }

            return query.ToList();
        }

        public TEntity IncludeEntityById( List<string> includes, Expression<Func<TEntity, bool>> filter = null)
        {                        
            var query = Context.Set<TEntity>().Where(filter);
            
            foreach (var include in includes)
            {
                query = query.Include((include.ToString()));
            }
            
            return query.FirstOrDefault();
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefault(predicate);
        }

    }
}
