using Dominio.Contracts.Repositorios;
using Dominio.Entidades;
using Infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Persistence.Repositorys
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext context;

        public ClientRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Task<List<Client>> GetAll()
        {
            return context.Clients.Include(c => c.Sex).
                Include(c => c.Usuario).
                Include(c => c.Nacionality).ToListAsync();
        }

        public Task<Client> GetBySClient(string codigo)
        {
            return context.Clients.
                Include(c => c.Sex).
                Include(c => c.Usuario).
                Include(c => c.Nacionality).
                FirstOrDefaultAsync(c => c.SClient == codigo);
        }
    }
}
