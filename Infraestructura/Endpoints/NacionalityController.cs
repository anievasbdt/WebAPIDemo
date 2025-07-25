﻿using Aplicacion.Servicios;
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
    public class NacionalityController : ControllerBase
    {
        private readonly INacionalityService nacionalityService;

        public NacionalityController(INacionalityService nacionalityService)
        {
            this.nacionalityService = nacionalityService;
        }

        // GET /Table5518
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nacionality>>> GetTable5518()
        {
            ActionResult<IEnumerable<Nacionality>> resultado;
            try
            {
                List<Nacionality> nacionalitys = await nacionalityService.GetAll();
                resultado= Ok(nacionalitys);
            }
            catch (Exception ex)
            {
                resultado= StatusCode(500, ex.Message);
            }
            return resultado;
        }
    }
}
