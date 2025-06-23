using Dominio.Contracts.Repositorios;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Persistencia.Repositorios
{
    public class SexRepository : ISexRepository
    {
        private readonly AppDbContext context;

        public SexRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Task<List<Sex>> GetAll()
        {
            return context.Table18.Include(s => s.Usuario).ToListAsync();
        }
    }
}
