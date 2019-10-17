using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Tesarakt.Common.Models;

namespace Tesarakt.DAL.Common.Repository
{
   public class EntityRepositoryBase<TContext, TEntity, TId> : RepositoryBase<TContext>, IRepository<TEntity, TId> where TContext : DbContext where TEntity : class, IEntityRequiredProperties<TId>, new () where TId : IComparable
    {
        public EntityRepositoryBase(TContext context):base (context)
        {
         
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

        public void Add(TEntity entity)
        {
            if (entity == null) throw new InvalidOperationException("Unable to add null entity to repository");

            Context.Set<TEntity>().Add(entity);

        }

        public TEntity Update(TEntity entity)
        {
            return Context.Set<TEntity>().Update(entity).Entity;
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Attach(entity);
            Context.Entry(entity).State = EntityState.Deleted;
            Context.Set<TEntity>().Remove(entity);
        }

        public void Remove(TId id)
        {
            var entity = new TEntity { Id = id };
            this.Remove(entity);
           
            
        }

        public void Remove(ICollection<TEntity> entities)
        {
            Context.Set<TEntity>().AttachRange(entities);
            Context.Set<TEntity>().RemoveRange(entities);
        }
    }
}
