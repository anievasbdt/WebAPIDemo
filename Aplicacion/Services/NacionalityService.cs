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
    public class NacionalityService : INacionalityService
    {
        private readonly INacionalityRepository nacionalityRepository;

        public NacionalityService(INacionalityRepository nacionalityRepository)
        {
            this.nacionalityRepository = nacionalityRepository;
        }

        public Task<List<Nacionality>> GetAll()
        {
            return nacionalityRepository.GetAll();
        }
    }
}
