using Aplicacion.Servicios;
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
    public class NMPolizaController : ControllerBase
    {
        private readonly INMPolizaService nmpolizaService;

        public NMPolizaController(INMPolizaService nmpolizaService)
        {
            this.nmpolizaService = nmpolizaService;
        }

        // GET /Table13
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NMPoliza>>> GetTable13()
        {
            ActionResult<IEnumerable<NMPoliza>> resultado;
            try
            {
                List<NMPoliza> nmpoliza = await nmpolizaService.GetAll();
                resultado= Ok(nmpoliza);
            }
            catch (Exception ex)
            {
                resultado= StatusCode(500, ex.Message);
            }
            return resultado;
        }
    }
}
