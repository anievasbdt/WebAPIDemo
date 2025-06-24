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
            ActionResult<Premium> resultado;
            try
            {
                Premium premium = await premiumService.GetPremium(nreceipt);
                if (premium == null)
                {
                    resultado= NotFound();
                }
                resultado = Ok(premium);
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

        [HttpGet("{nBranch}/{nProduct}/{nPolicy}")]
        public async Task<ActionResult<IEnumerable<Premium>>> GetPremiumXPoliza(int nBranch, int nProduct, int nPolicy)
        {
            ActionResult<IEnumerable<Premium>> resultado;
            try
            {
                List<Premium> premiums = await premiumService.GetPremiumXPoliza(nBranch,nProduct,nPolicy);
                resultado = Ok(premiums);
            }
            catch (Exception ex)
            {
                resultado = StatusCode(500, ex.Message);
            }
            return resultado;
        }

        [HttpGet("EnvioACobro/{nWayPay}")]
        public async Task<ActionResult<IEnumerable<Premium>>> GetPremiumXEnvioACobro(int nWayPay)
        {
            ActionResult<IEnumerable<Premium>> resultado;
            try
            {
                List<Premium> premiums = await premiumService.GetPremiumXEnvioACobro(nWayPay);
                resultado = Ok(premiums);
            }
            catch (Exception ex)
            {
                resultado = StatusCode(500, ex.Message);
            }
            return resultado;
        }
    }
}