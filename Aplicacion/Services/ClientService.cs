using Dominio.Contracts.Repositorios;
using Dominio.Contracts.Servicios;
using Dominio.DTOs.Request;
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

        public bool CreateJuridicClient(NewClientJuridicoRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Request cannot be null");
            }
            Client client = new Client
            {
                SClient = request.RucCUIT,
                SLegalName = request.RazonSocial,
                SCuit = request.RucCUIT,
                NNationality = request.Nacionalidad,
                DBirthDat = request.FechaConstitucion.ToDateTime(new TimeOnly(0, 0)),
                SFirstName = null,
                SLastName = null,
                SLastName2 = null,
                SSexClien = null
            };
            return clientRepository.CreateJuridicClient(client).Result;
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
