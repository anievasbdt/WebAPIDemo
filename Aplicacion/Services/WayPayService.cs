using Dominio.Contracts.Repositorios;
using Dominio.Contracts.Repositorys;
using Dominio.Contracts.Services;
using Dominio.DTOs.Response;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Services
{
    public class WayPayService : IWayPayService
    {
        private readonly IWayPayRepository wayPayRepository;

        public WayPayService(IWayPayRepository wayPayRepository)
        {
            this.wayPayRepository = wayPayRepository;
        }

        public List<WayPayComboBoxResponse> GetAll()
        {
            // Assuming WayPayComboBoxResponse is a DTO that maps to WayPay entity
            List<WayPay> wayPays = wayPayRepository.GetAll().Result;
            List<WayPayComboBoxResponse> response = wayPays.Select(wp => new WayPayComboBoxResponse
            {
                NWAY_PAY = wp.NWay_Pay,
                SDESCRIPT = wp.SDescript == null ? string.Empty : wp.SDescript.Trim()
            }).ToList();
            return response;
        }
        public List<WayPayTablaMantResponse> GetAllMant()
        {
            // Assuming WayPayTablaMantResponse is a DTO that maps to WayPay entity
            List<WayPay> wayPays = wayPayRepository.GetAll().Result;
            List<WayPayTablaMantResponse> response = wayPays.Select(wp => new WayPayTablaMantResponse
            {
                NWay_Pay = wp.NWay_Pay,
                SDescript = wp.SDescript == null ? string.Empty : wp.SDescript.Trim(),
                DCompDate = wp.DCompDate,
                NStatRegt = wp.NStatRegt,
                SUserCode = wp.Usuario.SInitials == null ? string.Empty : wp.Usuario.SInitials.Trim()
            }).ToList();
            return response;
        }
    }
}
