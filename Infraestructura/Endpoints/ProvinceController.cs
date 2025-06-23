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
    public class ProvinceController : ControllerBase
    {
        private readonly IProvinceService provinceService;

        public ProvinceController(IProvinceService provinceService)
        {
            this.provinceService = provinceService;
        }

        // GET /Province
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Province>>> GetProvince()
        {
            try
            {
                var provinces = await provinceService.GetAll();
                return Ok(provinces);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
