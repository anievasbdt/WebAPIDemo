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
    public class ProductMasterRepository : IProductMasterRepository
    {
        private readonly AppDbContext context;

        public ProductMasterRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Task<List<ProductMaster>> GetProductMasterXBranch(int nBranch)
        {
            return context.ProductMaster.
                Include(p => p.Branch).
                Include(p => p.Usuario).
                Where(p=>p.NBranch == nBranch).ToListAsync();
        }
    }
}
