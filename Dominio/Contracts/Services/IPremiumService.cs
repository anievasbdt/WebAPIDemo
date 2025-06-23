using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Contracts.Services
{
    public interface IPremiumService
    {
        Task<Premium> GetPremium(int codigo);
        Task<List<Premium>> GetPremiumXPoliza(int nBranch, int nProduct, int nPolicy);
        Task<List<Premium>> GetPremiumXEnvioACobro(int nWayPay);

    }
}
