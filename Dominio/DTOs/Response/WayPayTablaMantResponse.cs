using Dominio.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dominio.DTOs.Response
{
    public class WayPayTablaMantResponse
    {
        public int NWay_Pay { get; set; }
        public string SDescript { get; set; }
        public DateTime DCompDate { get; set; } = DateTime.Now;
        public int NStatRegt { get; set; }
        public string SUserCode { get; set; } = string.Empty;
    }
}
