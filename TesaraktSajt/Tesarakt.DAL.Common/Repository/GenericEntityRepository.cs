using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tesarakt.Common.Models;

namespace Tesarakt.DAL.Common.Repository
{
    public class GenericEntityRepository<TEntity, TId> : EntityRepositoryBase<DbContext, TEntity, TId> where TEntity : class, IEntityRequiredProperties<TId>, new () where TId : IComparable
    {
        public GenericEntityRepository(DbContext context) : base(context)
        {
        }
    }
}
