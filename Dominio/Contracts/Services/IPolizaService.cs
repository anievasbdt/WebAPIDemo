using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Contracts.Services
{
    public interface IPolizaService
    {
        Task<List<Poliza>> GetBySClient(string codigo);
        Task<Poliza> GetPoliza(int nBranch, int nProduct, int nPolicy);
    }
}
