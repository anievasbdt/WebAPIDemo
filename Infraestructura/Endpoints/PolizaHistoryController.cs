using Aplicacion.Services;
using Aplicacion.Servicios;
using Dominio.Contracts.Services;
using Dominio.Contracts.Servicios;
using Dominio.Entidades;
using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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
            ActionResult<IEnumerable<PolizaHistory>> resultado;
            try
            {
                List<PolizaHistory> polizaHistory = await polizaHistoryService.GetPolizaHistory(nBranch,nProduct,nPolicy);
                if (polizaHistory == null)
                {
                    resultado= NotFound();
                }
                resultado = Ok(polizaHistory);
            }
            catch (NotImplementedException)
            {
                resultado = StatusCode(501, "Method not implemented");
            }
            catch (Exception ex)
            {
                resultado = StatusCode(500, ex.Message);
            }
            return resultado;
        }
    }
}
