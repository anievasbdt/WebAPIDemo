using Dominio.Entidades;

namespace Dominio.Contracts.Servicios;

public interface IUsuarioService
{
    Task<List<Usuario>> GetAll();
    Task<Usuario> GetUsuarioByUserCode(int userCode);
}
