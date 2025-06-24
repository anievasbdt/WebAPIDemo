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
    public class BranchController : ControllerBase
    {

        private readonly IBranchService branchService;

        public BranchController(IBranchService branchService)
        {
            this.branchService = branchService;
        }

        // GET /Table10
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Branch>>> GetTable10()
        {
            ActionResult<IEnumerable<Branch>> result;
            try
            {
                List<Branch> branchs = await branchService.GetAll();
                result =  Ok(branchs);
            }
            catch (Exception ex)
            {
                result= StatusCode(500, ex.Message);
            }
            return result;
        }
    }
}
