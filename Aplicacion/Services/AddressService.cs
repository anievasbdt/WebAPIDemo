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
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }

        public Task<Address> GetAddress(int nrecowner, int skeyaddress, int sinfor)
        {
            return addressRepository.GetAddress(nrecowner, skeyaddress, sinfor);
        }
    }
}
