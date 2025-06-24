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
            ActionResult<IEnumerable<Province>> resultado;
            try
            {
                List<Province> provinces = await provinceService.GetAll();
                resultado= Ok(provinces);
            }
            catch (Exception ex)
            {
                resultado= StatusCode(500, ex.Message);
            }
            return resultado;
        }
    }
}
