using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tesarakt.DAL.Common.Repository;

namespace Tesarakt.DAL.Common.UoW
{
    public class UnitOfWorkBase<TContext> : IUnitOfWorkBase where TContext : DbContext
    {
        protected TContext _context;
        protected IServiceProvider _serviceProvider;

        public  UnitOfWorkBase( TContext context, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _context = context;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IRepository<TEntity, TId> GetRepository<TEntity, TId>()
        {

            try
            {
                var repoType = typeof(IRepository<TEntity, TId>);
                var repository = (IRepository<TEntity, TId>)_serviceProvider.GetService(repoType);



                return repository;
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();   
        }

        public Task<int> SaveChangesAsync()
        {
            return  _context.SaveChangesAsync();
        }
    }
}
