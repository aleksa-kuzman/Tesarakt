using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tesarakt.DAL.Common.Repository
{
    public class GenericEntityRepository<TEntity, TId> : EntityRepositoryBase<DbContext, TEntity, TId> where TEntity : class
    {
        public GenericEntityRepository(DbContext context) : base(context)
        {
        }
    }
}
