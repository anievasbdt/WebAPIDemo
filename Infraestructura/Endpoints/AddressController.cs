using Microsoft.AspNetCore.Mvc;
using Infraestructura.Persistencia;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Endpoints
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AddressController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{nrecowner}/{skeyaddress}/{sinfor}")]
        public async Task<ActionResult<Address>> GetAddress(int nrecowner, int skeyaddress, int sinfor)
        {
            var address = await _context.Address
                .Include(a => a.TabLocat)
                .Include(a => a.Municipality)
                .Include(a => a.Province)
                .Include(a => a.Poliza)
                .Include(a => a.Client)
                .Include(a => a.Usuario)

                .FirstOrDefaultAsync(a => a.NRecOwner == nrecowner && a.SKeyAddress == skeyaddress && a.SInfor == sinfor);

            if (address == null)
            {
                return NotFound();
            }
            return address;
        }
    }
}
