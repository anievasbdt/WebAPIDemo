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
    public class SexService : ISexService
    {
        private readonly ISexRepository sexRepository;

        public SexService(ISexRepository sexRepository)
        {
            this.sexRepository = sexRepository;
        }

        public Task<List<Sex>> GetAll()
        {
            return sexRepository.GetAll();
        }
    }
}
