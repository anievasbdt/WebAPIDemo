using Aplicacion.Servicios;
using Dominio.Contracts.Services;
using Dominio.Contracts.Servicios;
using Dominio.Entidades;
using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infraestructura.Endpoints
{
    [ApiController]
    [Route("[controller]")]
    public class PremiumController : ControllerBase
    {
        private readonly IPremiumService premiumService;

        public PremiumController(IPremiumService premiumService)
        {
            this.premiumService = premiumService;
        }

        [HttpGet("Receipt/{nreceipt}")]
        public async Task<ActionResult<Premium>> GetPremium(int nreceipt)
        {
            try
            {
                var premium = await premiumService.GetPremium(nreceipt);
                if (premium == null)
                {
                    return NotFound();
                }
                return Ok(premium);
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

        [HttpGet("{nBranch}/{nProduct}/{nPolicy}")]
        public async Task<ActionResult<IEnumerable<Premium>>> GetPremiumXPoliza(int nBranch, int nProduct, int nPolicy)
        {
            try
            {
                var premiums = await premiumService.GetPremiumXPoliza(nBranch,nProduct,nPolicy);
                return Ok(premiums);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("EnvioACobro/{nWayPay}")]
        public async Task<ActionResult<IEnumerable<Premium>>> GetPremiumXEnvioACobro(int nWayPay)
        {
            try
            {
                var premiums = await premiumService.GetPremiumXEnvioACobro(nWayPay);
                return Ok(premiums);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}