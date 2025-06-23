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
    public class SexController : ControllerBase
    {
        private readonly ISexService sexService;

        public SexController(ISexService sexService)
        {
            this.sexService = sexService;
        }

        // GET /Table18

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sex>>> GetTable18()
        {
            try
            {
                var sexs = await sexService.GetAll();
                return Ok(sexs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
