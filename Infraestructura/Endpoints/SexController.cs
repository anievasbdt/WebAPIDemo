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
            ActionResult<IEnumerable<Sex>> resultado;
            try
            {
                List<Sex> sexs = await sexService.GetAll();
                resultado= Ok(sexs);
            }
            catch (Exception ex)
            {
                resultado= StatusCode(500, ex.Message);
            }
            return resultado;
        }
    }
}
