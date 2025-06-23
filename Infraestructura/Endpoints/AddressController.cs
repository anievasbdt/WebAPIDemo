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
            try
            {
                var address = await addressService.GetAddress(nrecowner,skeyaddress,sinfor);
                if (address == null)
                {
                    return NotFound();
                }
                return Ok(address);
            }
            catch (NotImplementedException)
            {
                return StatusCode(501, "Method not implemented");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
