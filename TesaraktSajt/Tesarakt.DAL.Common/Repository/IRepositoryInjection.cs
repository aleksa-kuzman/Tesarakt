using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tesarakt.DAL.Common.Repository
{
    public interface IRepositoryInjection<TContext> where TContext : DbContext
    {
        IRepositoryInjection<TContext> SetContext(TContext context);
    }
}
