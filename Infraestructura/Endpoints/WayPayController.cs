using Aplicacion.Servicios;
using Dominio.Contracts.Services;
using Dominio.Contracts.Servicios;
using Dominio.DTOs.Response;
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
        public ActionResult<IEnumerable<WayPayComboBoxResponse>> GetTable5002()
        {
            ActionResult<IEnumerable<WayPayComboBoxResponse>> resultado;
            try
            {
                List<WayPayComboBoxResponse> wayPay = wayPayService.GetAll();
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
