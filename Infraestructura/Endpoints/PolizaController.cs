using Aplicacion.Servicios;
using Dominio.Contracts.Services;
using Dominio.Contracts.Servicios;
using Dominio.Entidades;
using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Endpoints
{
    [ApiController]
    [Route("[controller]")]
    public  class PolizaController : ControllerBase
    {
        private readonly IPolizaService polizaService;

        public PolizaController(IPolizaService polizaService)
        {
            this.polizaService = polizaService;
        }

        [HttpGet("{nBranch}/{nProduct}/{nPolicy}")]
        public async Task<ActionResult<Poliza>> GetPoliza(int nBranch, int nProduct, int nPolicy)
        {
            ActionResult<Poliza> resultado;
            try
            {
                Poliza poliza = await polizaService.GetPoliza(nBranch,nProduct,nPolicy);
                if (poliza == null)
                {
                    resultado= NotFound();
                }
                resultado = Ok(poliza);
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

        [HttpGet("{sclient}")]
        public async Task<ActionResult<IEnumerable<Poliza>>> GetPolizasBySClient(string sclient)
        {
            ActionResult<IEnumerable<Poliza>> resultado;
            try
            {
                List<Poliza> poliza = await polizaService.GetBySClient(sclient);
                if (poliza == null)
                {
                    resultado = NotFound();
                }
                resultado = Ok(poliza);
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
