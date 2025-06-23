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
    public class NMPremiumController : ControllerBase
    {
        private readonly INMPremiumService nMPremiumService;

        public NMPremiumController(INMPremiumService nMPremiumService)
        {
            this.nMPremiumService = nMPremiumService;
        }

        // GET /Table95
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NMPremium>>> GetTable95()
        {
            try
            {
                var nmpremium = await nMPremiumService.GetAll();
                return Ok(nmpremium);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
