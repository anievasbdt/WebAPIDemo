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
    public class PremiumService : IPremiumService
    {
        private readonly IPremiumRepository premiumRepository;

        public PremiumService(IPremiumRepository premiumRepository)
        {
            this.premiumRepository = premiumRepository;
        }

        public Task<Premium> GetPremium(int codigo)
        {
            return premiumRepository.GetPremium(codigo);
        }

        public Task<List<Premium>> GetPremiumXEnvioACobro(int nWayPay)
        {
            return premiumRepository.GetPremiumXEnvioACobro(nWayPay);
        }

        public Task<List<Premium>> GetPremiumXPoliza(int nBranch, int nProduct, int nPolicy)
        {
            return premiumRepository.GetPremiumXPoliza(nBranch,nProduct,nPolicy);
        }
    }
}
