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
    public class NMPolizaRepository : INMPolizaRepository
    {
        private readonly AppDbContext context;

        public NMPolizaRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Task<List<NMPoliza>> GetAll()
        {
            return context.Table13.
                Include(n => n.Usuario).ToListAsync();
        }
    }
}
