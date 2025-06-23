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
    public class WayPayService : IWayPayService
    {
        private readonly IWayPayRepository wayPayRepository;

        public WayPayService(IWayPayRepository wayPayRepository)
        {
            this.wayPayRepository = wayPayRepository;
        }

        public Task<List<WayPay>> GetAll()
        {
            return wayPayRepository.GetAll();
        }
    }
}
