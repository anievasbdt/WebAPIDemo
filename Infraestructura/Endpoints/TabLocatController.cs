using Aplicacion.Servicios;
using Dominio.Contracts.Services;
using Dominio.Contracts.Servicios;
using Dominio.Entidades;
using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infraestructura.Endpoints
{
    [ApiController]
    [Route("[controller]")]
    public class TabLocatController : ControllerBase
    {
        private readonly ITabLocatService tabLocatService;

        public TabLocatController(ITabLocatService tabLocatService)
        {
            this.tabLocatService = tabLocatService;
        }

        // GET /Tab_Locat
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TabLocat>>> GetTab_Locat()
        {
            try
            {
                var tabLocats = await tabLocatService.GetAll();
                return Ok(tabLocats);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
