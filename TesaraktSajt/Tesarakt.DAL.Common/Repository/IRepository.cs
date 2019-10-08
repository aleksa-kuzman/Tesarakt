using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tesarakt.DAL.Common.Repository
{
    public interface IRepository<TEntity,TId>
    {
        IEnumerable<TEntity> GetAll(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null);
    }
}
