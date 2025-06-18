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
        private readonly AppDbContext _context;

        public PremiumController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("Receipt/{nreceipt}")]
        public async Task<ActionResult<Premium>> GetPremium(int nreceipt)
        {
            var premium = await _context.Premium
                .Include(p => p.WayPay)
                .Include(p => p.StatusPre)
                .Include(p => p.StatusPay)
                .Include(p => p.NullCode)
                .Include(p => p.Usuario)
                .Include(p => p.ProductMaster)
                .Include(p => p.ProductMaster)
                .Include(p => p.Poliza)
                .FirstOrDefaultAsync(p => p.NReceipt == nreceipt);

            if (premium == null)
            {
                return NotFound();
            }
            return premium;
        }

        [HttpGet("{nBranch}/{nProduct}/{nPolicy}")]
        public async Task<ActionResult<IEnumerable<Premium>>> GetPremiumXPoliza(int nBranch, int nProduct, int nPolicy)
        {
            var premiums = await _context.Premium
                .Include(p => p.WayPay)
                .Include(p => p.StatusPre)
                .Include(p => p.StatusPay)
                .Include(p => p.NullCode)
                .Include(p => p.Usuario)
                .Include(p => p.ProductMaster)
                .Include(p => p.Poliza)
                .Where(p => p.NBranch == nBranch && p.NProduct == nProduct && p.NPolicy == nPolicy)
                .ToListAsync();

            if (premiums == null || !premiums.Any())
            {
                return NotFound();
            }
            return premiums;
        }

        [HttpGet("EnvioACobro/{nWayPay}")]
        public async Task<ActionResult<IEnumerable<Premium>>> GetPremiumXEnvioACobro(int nWayPay)
        {
            var premiums = await _context.Premium
                .FromSqlInterpolated($"SELECT * FROM PREMIUM PR WHERE PR.NWAY_PAY = {nWayPay} AND ((EXTRACT(MONTH FROM DEFFECDATE) = EXTRACT(MONTH FROM SYSDATE) AND EXTRACT(YEAR FROM DEFFECDATE) = EXTRACT(YEAR FROM SYSDATE) AND DNULLDATE IS NULL AND NSTATUS_PAY IS NULL AND NSTATUS_PRE = 1) OR (EXTRACT(MONTH FROM DEFFECDATE) <= EXTRACT(MONTH FROM SYSDATE) AND EXTRACT(YEAR FROM DEFFECDATE) <= EXTRACT(YEAR FROM SYSDATE) AND NSTATUS_PAY = 3))")
                .Include(p => p.WayPay)
                .Include(p => p.StatusPre)
                .Include(p => p.StatusPay)
                .Include(p => p.NullCode)
                .Include(p => p.Usuario)
                .Include(p => p.ProductMaster)
                .Include(p => p.Poliza)
                .ToListAsync();

            if (premiums == null || !premiums.Any())
            {
                return NotFound();
            }
            return premiums;
        }
    }
}