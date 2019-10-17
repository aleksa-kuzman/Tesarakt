using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tesarakt.DAL.Common.Repository
{
    public abstract class RepositoryBase<TContext> : IRepositoryInjection<TContext> where TContext : DbContext
    {

        protected TContext Context { get; private set; }
        public RepositoryBase(TContext context)
        {
            Context = context;
        }
        public IRepositoryInjection<TContext> SetContext(TContext context)
        {
            this.Context = context;
            return this;
        }
    }
}
