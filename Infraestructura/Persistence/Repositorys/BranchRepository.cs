using Dominio.Contracts.Repositorios;
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
    public class BranchRepository : IBranchRepository
    {
        private readonly AppDbContext context;

        public BranchRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Task<List<Branch>> GetAll()
        {
            return context.Table10.
                Include(a => a.Usuario).ToListAsync();
        }
    }
}
