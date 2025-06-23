using Aplicacion.Servicios;
using Dominio.Contracts.Services;
using Dominio.Contracts.Servicios;
using Dominio.Entidades;
using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Endpoints
{
    [ApiController]
    [Route("[controller]")]
    public class PolizaHistoryController : ControllerBase
    {
        private readonly IPolizaHistoryService polizaHistoryService;

        public PolizaHistoryController(IPolizaHistoryService polizaHistoryService)
        {
            this.polizaHistoryService = polizaHistoryService;
        }


        [HttpGet("{nBranch}/{nProduct}/{nPolicy}")]
        public async Task<ActionResult<IEnumerable<PolizaHistory>>> GetPoliza_History(int nBranch, int nProduct, int nPolicy)
        {
            try
            {
                var polizaHistory = await polizaHistoryService.GetPolizaHistory(nBranch,nProduct,nPolicy);
                if (polizaHistory == null)
                {
                    return NotFound();
                }
                return Ok(polizaHistory);
            }
            catch (NotImplementedException)
            {
                return StatusCode(501, "Method not implemented");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
