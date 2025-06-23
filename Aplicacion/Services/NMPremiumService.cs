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
    public class NMPremiumService : INMPremiumService
    {
        private readonly INMPremiumRepository nMPremiumRepository;

        public NMPremiumService(INMPremiumRepository nMPremiumRepository)
        {
            this.nMPremiumRepository = nMPremiumRepository;
        }

        public Task<List<NMPremium>> GetAll()
        {
            return nMPremiumRepository.GetAll();
        }
    }
}
