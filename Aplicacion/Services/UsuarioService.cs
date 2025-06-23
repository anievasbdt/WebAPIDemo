using Dominio.Contracts.Repositorios;
using Dominio.Contracts.Servicios;
using Dominio.Entidades;

namespace Aplicacion.Servicios;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository usuarioRepository;

    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        this.usuarioRepository = usuarioRepository;
    }


    public Task<List<Usuario>> GetAll()
    {
        return usuarioRepository.GetAll();
    }

    public Task<Usuario> GetUsuarioByUserCode(int userCode)
    {
        return usuarioRepository.GetByUserCode(userCode);
    }
}
