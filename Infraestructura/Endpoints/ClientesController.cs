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
    public class ClientsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientsController(AppDbContext context)
        {
            _context = context;
        }

        // GET /clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            return await _context.Clients.Include(c => c.Usuario).ToListAsync();
        }

        // GET /clients/{id}
        [HttpGet("{sclient}")]
        public async Task<ActionResult<Client>> GetClient(string sclient)
        {
            var client = await _context.Clients
                .Include(c => c.Usuario) // Eager load the Usuario relationship
                .FirstOrDefaultAsync(c => c.SClient == sclient); // Replace FindAsync with FirstOrDefaultAsync

            if (client == null)
            {
                return NotFound();
            }
            return client;
        }

        //// POST /clients
        //[HttpPost]
        //public async Task<ActionResult<Client>> PostClient(Client client)
        //{
        //    _context.Clients.Add(client);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction(nameof(GetClient), new { id = client.SClient }, client);
        //}

        //// PUT /clients/{id}
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutClient(string id, Client client)
        //{
        //    if (id != client.SClient)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(client).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ClientExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}


        //private bool ClientExists(string id)
        //{
        //    return _context.Clients.Any(e => e.SClient == id);
        //}
    }
}
