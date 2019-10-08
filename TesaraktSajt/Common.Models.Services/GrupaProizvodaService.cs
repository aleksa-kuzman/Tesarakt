using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
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
                var a = _uow.GetRepository<GrupaProizvoda, int>().GetAll();
                return a;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
