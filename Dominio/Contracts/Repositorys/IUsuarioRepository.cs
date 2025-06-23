using Dominio.Entidades;

namespace Dominio.Contracts.Repositorios;

public interface IUsuarioRepository
{
    Task<Usuario> GetByUserCode(int codigo);
    Task<List<Usuario>> GetAll();

}
