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
    public class WayPayRepository : IWayPayRepository
    {
        private readonly AppDbContext context;

        public WayPayRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Task<List<WayPay>> GetAll()
        {
            return context.Table5002.Include(w => w.Usuario).ToListAsync();
        }
    }
}
