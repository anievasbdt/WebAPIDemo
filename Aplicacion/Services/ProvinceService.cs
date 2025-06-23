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
    public class ProvinceService : IProvinceService
    {
        private readonly IProvinceRepository provinceRepository;

        public ProvinceService(IProvinceRepository provinceRepository)
        {
            this.provinceRepository = provinceRepository;
        }

        public Task<List<Province>> GetAll()
        {
            return provinceRepository.GetAll();
        }
    }
}
