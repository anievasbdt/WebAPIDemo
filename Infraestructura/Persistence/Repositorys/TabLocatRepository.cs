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
    public class TabLocatRepository : ITabLocatRepository
    {
        private readonly AppDbContext context;

        public TabLocatRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Task<List<TabLocat>> GetAll()
        {
            return context.Tab_Locat.Include(t => t.Usuario).ToListAsync();
        }
    }
}
