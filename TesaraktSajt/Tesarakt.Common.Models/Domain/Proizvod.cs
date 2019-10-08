using System;
using System.Collections.Generic;

namespace Tesarakt.Common.Models.Domain
{
    public partial class Proizvod
    {
        public int ProizvodId { get; set; }
        public string NazivProizvoda { get; set; }
        public double? CenaProizvoda { get; set; }
        public int? GrupaId { get; set; }
    }
}
