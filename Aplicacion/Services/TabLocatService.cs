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
    public class TabLocatService : ITabLocatService
    {
        private readonly ITabLocatRepository tabLocatRepository;

        public TabLocatService(ITabLocatRepository tabLocatRepository)
        {
            this.tabLocatRepository = tabLocatRepository;
        }

        public Task<List<TabLocat>> GetAll()
        {
            return tabLocatRepository.GetAll();
        }
    }
}
