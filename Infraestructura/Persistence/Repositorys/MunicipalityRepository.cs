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
    public class MunicipalityRepository : IMunicipalityRepository
    {
        private readonly AppDbContext context;

        public MunicipalityRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Task<List<Municipality>> GetAll()
        {
            return context.Municipality.
                Include(m => m.Province).
                ToListAsync();
        }
    }
}
