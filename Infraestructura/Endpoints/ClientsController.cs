using Aplicacion.Servicios;
using Dominio.Contracts.Servicios;
using Dominio.DTOs.Request;
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
            ActionResult<IEnumerable<Client>> resultado;
            try
            {
                List<Client> clients = await clientService.GetAll();
                resultado = Ok(clients);
            }
            catch (Exception ex)
            {
                resultado = StatusCode(500, ex.Message);
            }
            return resultado;
        }

        // GET /clients/{id}
        [HttpGet("{sclient}")]
        public async Task<ActionResult<Client>> GetClient(string sclient)
        {
            ActionResult<Client> resultado;
            try
            {
                Client client = await clientService.GetClientBySClient(sclient);
                if (client == null)
                {
                    resultado = NotFound();
                }
                resultado = Ok(client);
            }
            catch (NotImplementedException)
            {
                resultado = StatusCode(501, "Method not implemented");
            }
            catch (Exception ex)
            {
                resultado = StatusCode(500, ex.Message);
            }
            return resultado;
        }

        /*
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
        */

        [HttpPost("new")]
        public ActionResult<bool> CreateClient([FromBody] NewClientJuridicoRequest request)
        {
            ActionResult result;
            try
            {
                clientService.CreateJuridicClient(request);

                result = Ok(true); // Retorna true si la creación fue exitosa
            }
            catch (Exception ex)
            {
                result = StatusCode(500, ex.Message); // Manejo de errores
            }
            return result;
        }
    }
}
