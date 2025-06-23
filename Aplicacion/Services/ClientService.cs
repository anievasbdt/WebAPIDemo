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
    public class ClientService : IClientService
    {
        private readonly IClientRepository clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        public Task<List<Client>> GetAll()
        {
            return clientRepository.GetAll();
        }

        public Task<Client> GetClientBySClient(string sclient)
        {
            return clientRepository.GetBySClient(sclient);
        }
    }
}
