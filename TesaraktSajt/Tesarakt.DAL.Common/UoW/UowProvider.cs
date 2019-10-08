using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tesarakt.DAL.Common.UoW
{
    public class UowProvider : IUowProvider
    {
        private readonly IServiceProvider _serviceProvider;
        public UowProvider()
        { }

        public UowProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public IUnitOfWork CreateUnitOfWork<TEntityContext>() where TEntityContext : class
        {
            var _context = (DbContext)_serviceProvider.GetService(typeof(TEntityContext));

            var uow = new UnitOfWork(_context, _serviceProvider);

            return uow;
            
        }
       
    }
}
