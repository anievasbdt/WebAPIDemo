using Dominio.Contracts.Repositorys;
using Dominio.Entidades;
using Infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Persistence
{
    public class PolizaHistoryRepository : IPolizaHistoryRepository
    {
        private readonly AppDbContext context;

        public PolizaHistoryRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Task<PolizaHistory> GetPolizaHistory(int nBranch, int nProduct, int nPolicy)
        {
            return context.Poliza_History.Include(p => p.Client).
                Include(p => p.WayPay).
                Include(p => p.NullReason).
                Include(p => p.Usuario).
                Include(p => p.Branch).
                Include(p => p.Product).FirstOrDefaultAsync(p => p.NBranch == nBranch && p.NProduct == nProduct && p.NPolicy == nPolicy);
        }
    }
}
