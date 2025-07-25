﻿using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Contracts.Repositorios
{
    public interface IClientRepository
    {
        Task<Client> GetBySClient(string codigo);
        Task<List<Client>> GetAll();
        Task<bool> CreateJuridicClient(Client client);
    }
}
