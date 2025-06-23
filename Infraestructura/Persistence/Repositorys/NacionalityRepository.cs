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
    public class NacionalityRepository : INacionalityRepository
    {
        private readonly AppDbContext context;

        public NacionalityRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Task<List<Nacionality>> GetAll()
        {
            return context.Table5518.
               Include(n => n.Usuario).ToListAsync();
        }
    }
}
