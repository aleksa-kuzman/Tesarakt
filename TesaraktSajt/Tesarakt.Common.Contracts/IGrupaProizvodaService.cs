using System;
using System.Collections.Generic;
using System.Text;
using Tesarakt.Common.Models.Domain;

namespace Tesarakt.Common.Contracts
{
    public interface IGrupaProizvodaService
    {
        IEnumerable<GrupaProizvoda> GetAllGrupaProizvoda();
        GrupaProizvoda GetGrupa(int id);
        bool RemoveGrupa(int id);
        bool AddGrupa(GrupaProizvoda grupaProizvoda);
        bool DeactivateGrupa(int id);

    }
}
