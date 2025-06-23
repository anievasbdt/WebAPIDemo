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
    public class NMPolizaService : INMPolizaService
    {
        private readonly INMPolizaRepository nmpolizaRepository;

        public NMPolizaService(INMPolizaRepository nmpolizaRepository)
        {
            this.nmpolizaRepository = nmpolizaRepository;
        }

        public Task<List<NMPoliza>> GetAll()
        {
            return nmpolizaRepository.GetAll();
        }
    }
}
