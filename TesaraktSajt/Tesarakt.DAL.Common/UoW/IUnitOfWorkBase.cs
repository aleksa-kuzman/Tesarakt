using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tesarakt.DAL.Common.Repository;

namespace Tesarakt.DAL.Common.UoW
{
    public interface IUnitOfWorkBase : IDisposable
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();
        IRepository<TEntity, TId> GetRepository<TEntity, TId>();


    }
}
