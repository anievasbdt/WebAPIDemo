using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Contracts.Servicios
{
    public interface ISexService
    {
        Task<List<Sex>> GetAll();

    }
}
