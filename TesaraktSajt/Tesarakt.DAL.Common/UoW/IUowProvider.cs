using System;
using System.Collections.Generic;
using System.Text;

namespace Tesarakt.DAL.Common.UoW
{
    public interface IUowProvider
    {
       IUnitOfWork CreateUnitOfWork<TEntityContext>() where TEntityContext : class;
        


    }
}
