using Dominio.Contracts.Repositorios;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Persistencia.Repositorios
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext context;
        public AddressRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Task<Address> GetAddress(int nrecowner, int skeyaddress, int sinfor)
        {
            return context.Address.
                Include(a => a.TabLocat).
                Include(a => a.Municipality).
                Include(a => a.Province).
                Include(a => a.Poliza).
                Include(a => a.Client).
                Include(a => a.Usuario).
                FirstOrDefaultAsync(a => a.NRecOwner == nrecowner && a.SKeyAddress == skeyaddress && a.SInfor == sinfor);
        }
    }
}
