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
    public class MunicipalityController : ControllerBase
    {
        private readonly IMunicipalityService municipalityService;

        public MunicipalityController(IMunicipalityService municipalityService)
        {
            this.municipalityService = municipalityService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Municipality>>> GetMunicipality()
        {
            ActionResult<IEnumerable<Municipality>> resultado;
            try
            {
                List<Municipality> municipalitys = await municipalityService.GetAll();
                resultado= Ok(municipalitys);
            }
            catch (Exception ex)
            {
                resultado= StatusCode(500, ex.Message);
            }
            return resultado;
        }
    }
}