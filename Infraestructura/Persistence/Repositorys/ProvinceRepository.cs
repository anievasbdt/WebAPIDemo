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
    public class ProvinceRepository : IProvinceRepository
    {
        private readonly AppDbContext context;

        public ProvinceRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Task<List<Province>> GetAll()
        {
            return context.Province.Include(p => p.Usuario).ToListAsync();
        }
    }
}
