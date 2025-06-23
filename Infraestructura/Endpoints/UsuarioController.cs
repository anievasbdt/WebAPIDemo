using Microsoft.AspNetCore.Mvc;
using Dominio.Entidades;
using Dominio.Contracts.Servicios;

namespace Infraestructura.Endpoints
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            try
            {
                var usuarios = await usuarioService.GetAll();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{nusercode}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int nusercode)
        {
            try
            {
                var usuario = await usuarioService.GetUsuarioByUserCode(nusercode);
                if (usuario == null)
                {
                    return NotFound();
                }
                return Ok(usuario);
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