using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Contracts.Services
{
    public interface INacionalityService
    {
        Task<List<Nacionality>> GetAll();

    }
}
