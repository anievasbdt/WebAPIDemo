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
            ActionResult<IEnumerable<TabLocat>> resultado;
            try
            {
                List<TabLocat> tabLocats = await tabLocatService.GetAll();
                resultado= Ok(tabLocats);
            }
            catch (Exception ex)
            {
                resultado= StatusCode(500, ex.Message);
            }
            return resultado;
        }
    }
}
