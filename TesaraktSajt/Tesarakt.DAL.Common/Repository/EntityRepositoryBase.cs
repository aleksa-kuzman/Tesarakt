using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tesarakt.DAL.Common.Repository
{
   public class EntityRepositoryBase<TContext, TEntity, TId> : IRepository<TEntity, TId> where TContext : DbContext where TEntity: class
    {
        protected TContext Context { get; private set; }
        public EntityRepositoryBase(TContext context)
        {
            this.Context = context;
        }
        public IEnumerable<TEntity> GetAll(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();

            return query.ToList();
        }
    }
}
