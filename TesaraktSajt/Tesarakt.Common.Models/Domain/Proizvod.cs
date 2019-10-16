using System;
using System.Collections.Generic;

namespace Tesarakt.Common.Models.Domain
{
    public partial class Proizvod : IEntityRequiredProperties<int>
    {
        public int Id { get; set; }
        public string NazivProizvoda { get; set; }
        public double? CenaProizvoda { get; set; }
        public int? GrupaId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int ModifiedByUserId { get; set; }
        public bool Active { get; set; }
    }
}
