﻿using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Contracts.Repositorios
{
    public interface INMPolizaRepository
    {
        Task<List<NMPoliza>> GetAll();

    }
}
