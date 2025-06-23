using Aplicacion.Servicios;
using Dominio.Contracts.Servicios;
using Dominio.Entidades;
using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infraestructura.Endpoints
{
    [ApiController]
    [Route("[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService clientService;

        public ClientsController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        // GET /clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            try
            {
                var clients = await clientService.GetAll();
                return Ok(clients);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET /clients/{id}
        [HttpGet("{sclient}")]
        public async Task<ActionResult<Client>> GetClient(string sclient)
        {
            try
            {
                var client = await clientService.GetClientBySClient(sclient);
                if (client == null)
                {
                    return NotFound();
                }
                return Ok(client);
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
