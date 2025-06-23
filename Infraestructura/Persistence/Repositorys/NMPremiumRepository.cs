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
    public class NMPremiumRepository : INMPremiumRepository
    {
        private readonly AppDbContext context;

        public NMPremiumRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Task<List<NMPremium>> GetAll()
        {
            return context.Table95.
                Include(n => n.Usuario).ToListAsync();
        }
    }
}
