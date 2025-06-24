using Dominio.Contracts.Servicios;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
            ActionResult<IEnumerable<Usuario>> resultado;
            try
            {
                List<Usuario> usuarios = await usuarioService.GetAll();
                resultado= Ok(usuarios);
            }
            catch (Exception ex)
            {
                resultado= StatusCode(500, ex.Message);
            }
            return resultado;
        }

        [HttpGet("{nusercode}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int nusercode)
        {
            ActionResult<Usuario> resultado;
            try
            {
                Usuario usuario = await usuarioService.GetUsuarioByUserCode(nusercode);
                if (usuario == null)
                {
                    resultado= NotFound();
                }
                resultado= Ok(usuario);
            }
            catch (NotImplementedException)
            {
                resultado= StatusCode(501, "Method not implemented");
            }
            catch (Exception ex)
            {
                resultado= StatusCode(500, ex.Message);
            }
            return resultado;
        }
    }
}