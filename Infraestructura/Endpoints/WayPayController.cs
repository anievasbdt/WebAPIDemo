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
    public class WayPayController : ControllerBase
    {
        private readonly IWayPayService wayPayService;

        public WayPayController(IWayPayService wayPayService)
        {
            this.wayPayService = wayPayService;
        }

        // GET /Table5002
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WayPay>>> GetTable5002()
        {
            ActionResult<IEnumerable<WayPay>> resultado;
            try
            {
                List<WayPay> wayPay = await wayPayService.GetAll();
                resultado= Ok(wayPay);
            }
            catch (Exception ex)
            {
                resultado= StatusCode(500, ex.Message);
            }
            return resultado;
        }
    }
}
