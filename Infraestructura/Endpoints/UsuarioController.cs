using Microsoft.AspNetCore.Mvc;
using Infraestructura.Persistencia;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infraestructura.Endpoints
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        // GET /Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        [HttpGet("{nusercode}")]
        public async Task<ActionResult<Usuario>> GetUsuarios(int nusercode)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(c => c.NUsercode == nusercode); 

            if (usuario == null)
            {
                return NotFound();
            }
            return usuario;
        }
    }
}
