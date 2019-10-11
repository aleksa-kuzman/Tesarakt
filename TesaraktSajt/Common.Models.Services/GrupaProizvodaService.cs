using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tesarakt.Common.Contracts;
using Tesarakt.Common.Models.Domain;
using Tesarakt.DAL.Common.UoW;

namespace Common.Models.Services
{
   public class GrupaProizvodaService : IGrupaProizvodaService
    {
        IUowProvider _uowProvider;
        IUnitOfWork _uow;
        IServiceProvider _serviceProvider;
        IHttpContextAccessor _httpContextAccessor;
      

        public GrupaProizvodaService(IUowProvider uowProvider,IServiceProvider serviceProvider,IHttpContextAccessor httpContextAccessor)
        {
            _uowProvider = uowProvider;
            _serviceProvider = serviceProvider;
            _uow = uowProvider.CreateUnitOfWork<TesaraktContext>();
            _httpContextAccessor = httpContextAccessor;
        }

        
      
        public IEnumerable<GrupaProizvoda> GetAllGrupaProizvoda()
        {
            
            try
            {
                var a = _uow.GetRepository<GrupaProizvoda, int>().GetAll(null,m=>m.Where( f=>f.Id == 100 ));
                return a;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public GrupaProizvoda GetGrupa (int id)
        {
            try
            {
                return _uow.GetRepository<GrupaProizvoda, int>().GetAll(null, m => m.Where(f => f.Id == 100) ).SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        
    }
}
