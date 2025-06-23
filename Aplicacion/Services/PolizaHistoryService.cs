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
    public class PolizaHistoryService : IPolizaHistoryService
    {
        private readonly IPolizaHistoryRepository polizaHistoryRepository;

        public PolizaHistoryService(IPolizaHistoryRepository polizaHistoryRepository)
        {
            this.polizaHistoryRepository = polizaHistoryRepository;
        }

        public Task<PolizaHistory> GetPolizaHistory(int nBranch, int nProduct, int nPolicy)
        {
            return polizaHistoryRepository.GetPolizaHistory(nBranch,nProduct,nPolicy);
        }
    }
}
