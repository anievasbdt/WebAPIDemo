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
    public class PolizaRepository : IPolizaRepository
    {
        private readonly AppDbContext context;

        public PolizaRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Task<Poliza> GetBySClient(string codigo)
        {
            return context.Poliza.
                Include(p => p.Client).
                Include(p => p.WayPay).
                Include(p => p.NullCode).
                Include(p => p.Usuario).
                Include(p => p.Product).
                FirstOrDefaultAsync(p => p.SClient == codigo);
        }

        public Task<Poliza> GetPoliza(int nBranch, int nProduct, int nPolicy)
        {
            return context.Poliza.
                Include(p => p.Client).
                Include(p => p.WayPay).
                Include(p => p.NullCode).
                Include(p => p.Usuario).
                Include(p => p.Product).FirstOrDefaultAsync(p => p.NBranch == nBranch && p.NProduct == nProduct && p.NPolicy == nPolicy);
        }
    }
}
