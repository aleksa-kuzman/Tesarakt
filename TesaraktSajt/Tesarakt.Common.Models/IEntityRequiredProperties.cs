using System;
using System.Collections.Generic;
using System.Text;

namespace Tesarakt.Common.Models
{
    public interface IEntityRequiredProperties<T>
    {
         T Id { get; set; }
       /*  DateTime ModifiedDate { get; set; }
         T ModifiedByUserId { get; set; }
         bool Active { get; set; }*/
    }
}
