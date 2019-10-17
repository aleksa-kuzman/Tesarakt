﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Tesarakt.DAL.Common.Repository
{
    public interface IRepository<TEntity,TId>
    {
        IEnumerable<TEntity> GetAll(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null);
        IEnumerable<TEntity> Query(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null);
        TEntity Get(TId id, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null);
        TEntity Update(TEntity entity);
        void Add(TEntity entity);
        void Remove(TEntity entity);
        void Remove(TId id);
        void Remove(ICollection<TEntity> entities);
            

    }
}
