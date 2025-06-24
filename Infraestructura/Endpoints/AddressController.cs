using Aplicacion.Servicios;
using Dominio.Contracts.Servicios;
using Dominio.Entidades;
using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Endpoints
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService addressService;

        public AddressController(IAddressService addressService)
        {
            this.addressService = addressService;
        }

        [HttpGet("{nrecowner}/{skeyaddress}/{sinfor}")]
        public async Task<ActionResult<Address>> GetAddress(int nrecowner, int skeyaddress, int sinfor)
        {
            ActionResult<Address> result;
            try
            {
                Address address = await addressService.GetAddress(nrecowner,skeyaddress,sinfor);
                if (address == null)
                {
                    result= NotFound();
                }
                result= Ok(address);
            }
            catch (NotImplementedException)
            {
                result= StatusCode(501, "Method not implemented");
            }
            catch (Exception ex)
            {
                result= StatusCode(500, ex.Message);
            }
            return result;
        }
    }
}
