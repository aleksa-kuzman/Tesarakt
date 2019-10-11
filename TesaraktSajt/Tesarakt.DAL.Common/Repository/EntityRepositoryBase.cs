using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Tesarakt.Common.Models;

namespace Tesarakt.DAL.Common.Repository
{
   public class EntityRepositoryBase<TContext, TEntity, TId> : IRepository<TEntity, TId> where TContext : DbContext where TEntity : class, IEntityRequiredProperties<TId>, new () where TId : IComparable
    {
        protected TContext Context { get; private set; }
        public EntityRepositoryBase(TContext context)
        {
            this.Context = context;
        }
        public IEnumerable<TEntity> GetAll(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null)
        {
            var entities = QueryDb(null, orderBy, includes);

            return entities.ToList();
        }

        public IEnumerable<TEntity> Query(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func <IQueryable<TEntity>, IQueryable<TEntity> > includes = null)
        {
            var result = QueryDb(null, orderBy, includes);
            return result.AsNoTracking().ToList();
        }

        public TEntity Get(TId id, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null)
        {
            IQueryable<TEntity> entities = Context.Set<TEntity>();
            if(includes != null)
                entities = includes(entities);

            return entities.AsNoTracking().SingleOrDefault(m => m.Id.Equals(id));
            
        }


        protected IQueryable<TEntity> QueryDb(Expression<Func<TEntity,bool>> filter,/* */ Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, /* */ Func<IQueryable<TEntity>,IQueryable<TEntity>> includes)
        {


            IQueryable<TEntity> entities = Context.Set<TEntity>();
           
            if(filter != null)
            {
                entities = entities.Where(filter);
            }
            if (includes != null)
            {
                entities = includes(entities);
            }
            if(orderBy != null)
            {
                entities = orderBy(entities);
            }
            return entities;
        }
    }
}
