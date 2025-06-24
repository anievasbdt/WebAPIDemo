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
    public class ProductMasterController : ControllerBase
    {
        private readonly IProductMasterService productMasterService;

        public ProductMasterController(IProductMasterService productMasterService)
        {
            this.productMasterService = productMasterService;
        }

        // GET /ProductMaster
        [HttpGet("{nBranch}")]
        public async Task<ActionResult<IEnumerable<ProductMaster>>> GetProductMasterXBranch(int nBranch)
        {
            ActionResult<IEnumerable<ProductMaster>> resultado;
            try
            {
                List<ProductMaster> productsMaster = await productMasterService.GetProductMasterXBranch(nBranch);
                resultado= Ok(productsMaster);
            }
            catch (Exception ex)
            {
                resultado= StatusCode(500, ex.Message);
            }
            return resultado;
        }
    }
}
