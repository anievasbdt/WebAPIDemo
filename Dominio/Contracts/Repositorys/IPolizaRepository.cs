using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Contracts.Repositorys
{
    public interface IPolizaRepository
    {
        Task<Poliza> GetBySClient(string codigo);
        Task<Poliza> GetPoliza(int nBranch, int nProduct, int nPolicy);
    }
}
