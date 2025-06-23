using Dominio.Contracts.Repositorys;
using Dominio.Entidades;
using Infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Persistence.Repositorys
{
    public class PremiumRepository : IPremiumRepository
    {
        private readonly AppDbContext context;

        public PremiumRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Task<Premium> GetPremium(int codigo)
        {
            return context.Premium.
                Include(p => p.WayPay).
                Include(p => p.StatusPre).
                Include(p => p.StatusPay).
                Include(p => p.NullCode).
                Include(p => p.Usuario).
                Include(p => p.ProductMaster).
                Include(p => p.Poliza).
                FirstOrDefaultAsync(p => p.NReceipt == codigo);
        }

        public Task<List<Premium>> GetPremiumXEnvioACobro(int nWayPay)
        {
            return context.Premium.FromSqlInterpolated($"SELECT * FROM PREMIUM PR WHERE PR.NWAY_PAY = {nWayPay} AND ((EXTRACT(MONTH FROM DEFFECDATE) = EXTRACT(MONTH FROM SYSDATE) AND EXTRACT(YEAR FROM DEFFECDATE) = EXTRACT(YEAR FROM SYSDATE) AND DNULLDATE IS NULL AND NSTATUS_PAY IS NULL AND NSTATUS_PRE = 1) OR (EXTRACT(MONTH FROM DEFFECDATE) <= EXTRACT(MONTH FROM SYSDATE) AND EXTRACT(YEAR FROM DEFFECDATE) <= EXTRACT(YEAR FROM SYSDATE) AND NSTATUS_PAY = 3))").
                Include(p => p.WayPay).
                Include(p => p.StatusPre).
                Include(p => p.StatusPay).
                Include(p => p.NullCode).
                Include(p => p.Usuario).
                Include(p => p.ProductMaster).
                Include(p => p.Poliza).ToListAsync();

        }

        public Task<List<Premium>> GetPremiumXPoliza(int nBranch, int nProduct, int nPolicy)
        {
            return context.Premium.
                Include(p => p.WayPay).
                Include(p => p.StatusPre).
                Include(p => p.StatusPay).
                Include(p => p.NullCode).
                Include(p => p.Usuario).
                Include(p => p.ProductMaster).
                Include(p => p.Poliza).
                Where(p => p.NBranch == nBranch && p.NProduct == nProduct && p.NPolicy == nPolicy).ToListAsync();
        }
    }
}
