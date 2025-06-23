using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Contracts.Servicios
{
    public interface IClientService
    {
        Task<List<Client>> GetAll();
        Task<Client> GetClientBySClient(string sclient);
    }
}
