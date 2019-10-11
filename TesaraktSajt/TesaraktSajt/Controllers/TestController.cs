using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Models.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tesarakt.Common.Contracts;
using Tesarakt.Common.Models.Domain;
using Tesarakt.DAL.Common.Repository;
using Tesarakt.DAL.Common.UoW;

namespace TesaraktSajt.Controllers
{
    [Produces("application/json")]
    [Route("api/Test")]
    public class TestController : Controller
    {
        IGrupaProizvodaService _grupaProizvodaService;
    

        public TestController(IGrupaProizvodaService grupaProizvodaService)
        {
            _grupaProizvodaService = grupaProizvodaService;
           

        }

        [HttpGet]
        public IActionResult Get()
          {

            var res = _grupaProizvodaService.GetAllGrupaProizvoda();
            if (res != null)
                return new OkObjectResult(res);

            else return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var res = _grupaProizvodaService.GetGrupa(id);
            if (res != null)
                return new OkObjectResult(res);
            else return NotFound();

        }


    }
}