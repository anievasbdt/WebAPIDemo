using Dominio.Contracts.Repositorios;
using Dominio.Entidades;
using Infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Infraestructura.Persistence.Repositorys
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext context;

        public ClientRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Task<bool> CreateJuridicClient(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client), "Client cannot be null");
            }
            // llamamos al StoredProcedure SP_INSERT_CLIENT
            // que recibe 9 parametros:
            /*
            Comando.Parameters.Add("P_SCLIENT", OracleDbType.Char, Cliente.SCLIENT, ParameterDirection.Input)
            Comando.Parameters.Add("P_DBIRTHDAT", OracleDbType.Date, Cliente.DBIRTHDAT, ParameterDirection.Input)
            Comando.Parameters.Add("P_SFIRSTNAME", OracleDbType.Char, Cliente.SFIRSTNAME, ParameterDirection.Input)
            Comando.Parameters.Add("P_SLASTNAME", OracleDbType.Char, Cliente.SLASTNAME, ParameterDirection.Input)
            Comando.Parameters.Add("P_SLASTNAME2", OracleDbType.Char, Cliente.SLASTNAME2, ParameterDirection.Input)
            Comando.Parameters.Add("P_SCUIT", OracleDbType.Char, Cliente.SCUIT, ParameterDirection.Input)
            Comando.Parameters.Add("P_SLEGALNAME", OracleDbType.Char, Cliente.SLEGALNAME, ParameterDirection.Input)
            Comando.Parameters.Add("P_SSEXCLIEN", OracleDbType.Char, Cliente.SSEXCLIEN, ParameterDirection.Input)
            Comando.Parameters.Add("P_NNATIONALITY", OracleDbType.Char, Cliente.NNATIONALITY, ParameterDirection.Input)
             */
            OracleCommand command = new OracleCommand("user_insert", context.Database.GetDbConnection() as OracleConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("P_SCLIENT", OracleDbType.Char, client.SClient, ParameterDirection.Input);
            command.Parameters.Add("P_DBIRTHDAT", OracleDbType.Date, client.DBirthDat, ParameterDirection.Input);
            command.Parameters.Add("P_SFIRSTNAME", OracleDbType.Char, client.SFirstName, ParameterDirection.Input);
            command.Parameters.Add("P_SLASTNAME", OracleDbType.Char, client.SLastName, ParameterDirection.Input);
            command.Parameters.Add("P_SLASTNAME2", OracleDbType.Char, client.SLastName2, ParameterDirection.Input);
            command.Parameters.Add("P_SCUIT", OracleDbType.Char, client.SCuit, ParameterDirection.Input);
            command.Parameters.Add("P_SLEGALNAME", OracleDbType.Char, client.SLegalName, ParameterDirection.Input);
            command.Parameters.Add("P_SSEXCLIEN", OracleDbType.Char, client.SSexClien, ParameterDirection.Input);
            command.Parameters.Add("P_NNATIONALITY", OracleDbType.Int32, client.NNationality, ParameterDirection.Input);
            // ahora ejecutamos el comando
            try
            {
                command.ExecuteNonQuery();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, loguear el error o lanzar una excepción personalizada
                throw new Exception("Error al crear el cliente juridico", ex);
            }

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
