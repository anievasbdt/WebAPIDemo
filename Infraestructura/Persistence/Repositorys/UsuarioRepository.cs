using Dominio.Contracts.Repositorios;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Persistencia.Repositorios;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext context;

    public UsuarioRepository(AppDbContext context)
    {
        this.context = context;
    }

    public Task<List<Usuario>> GetAll()
    {
        return context.Usuarios.ToListAsync();
    }

    public Task<Usuario> GetByUserCode(int nUserCode)
    {
        return context.Usuarios.FirstOrDefaultAsync(c => c.NUsercode == nUserCode);
    }
}
