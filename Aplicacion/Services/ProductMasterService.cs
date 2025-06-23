using Dominio.Contracts.Repositorios;
using Dominio.Contracts.Repositorys;
using Dominio.Contracts.Services;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Services
{
    public class ProductMasterService : IProductMasterService
    {
        private readonly IProductMasterRepository productMasterRepository;

        public ProductMasterService(IProductMasterRepository productMasterRepository)
        {
            this.productMasterRepository = productMasterRepository;
        }

        public Task<List<ProductMaster>> GetProductMasterXBranch(int nBranch)
        {
            return productMasterRepository.GetProductMasterXBranch(nBranch);
        }
    }
}
