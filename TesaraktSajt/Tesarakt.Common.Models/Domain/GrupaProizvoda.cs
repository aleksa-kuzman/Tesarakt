﻿using System;
using System.Collections.Generic;

namespace Tesarakt.Common.Models.Domain
{
    public partial class GrupaProizvoda: IEntityRequiredProperties<int>
    {
        public int Id { get; set; }
        public string NazivGrupe { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int ModifiedByUserId { get; set; }
        public bool Active { get; set; }
    }
}
