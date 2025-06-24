using Dominio.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Contracts.Services
{
    public interface IWayPayService
    {
        List<WayPayComboBoxResponse> GetAll();
        List<WayPayTablaMantResponse> GetAllMant();

    }
}
