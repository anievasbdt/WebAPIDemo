using Dominio.Contracts.Repositorios;
using Dominio.Contracts.Servicios;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Servicios
{
    public class MunicipalityService : IMunicipalityService
    {
        private readonly IMunicipalityRepository municipalityRepository;

        public MunicipalityService(IMunicipalityRepository municipalityRepository)
        {
            this.municipalityRepository = municipalityRepository;
        }

        public Task<List<Municipality>> GetAll()
        {
            return municipalityRepository.GetAll();
        }
    }
}
