using Dominio.Contracts.Repositorios;
using Dominio.Contracts.Repositorys;
using Dominio.Contracts.Services;
using Dominio.Contracts.Servicios;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Services
{
    public class PolizaService : IPolizaService
    {
        private readonly IPolizaRepository polizaRepository;

        public PolizaService(IPolizaRepository polizaRepository)
        {
            this.polizaRepository = polizaRepository;
        }

        public Task<Poliza> GetBySClient(string codigo)
        {
            return polizaRepository.GetBySClient(codigo);
        }

        public Task<Poliza> GetPoliza(int nBranch, int nProduct, int nPolicy)
        {
            return polizaRepository.GetPoliza(nBranch,nProduct,nPolicy);
        }
    }
}
