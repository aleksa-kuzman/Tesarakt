using System.Collections.Generic;
using Tesarakt.Common.Models.Domain;

namespace Common.Models.Services
{
    public interface IGrupaProizvodaService
    {
        IEnumerable<GrupaProizvoda> GetAllGrupaProizvoda();
    }
}