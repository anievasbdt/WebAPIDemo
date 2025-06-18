using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Way_pay
    {
        [Key]
        [Column("NWAY_PAY")]
        public int NWay_Pay { get; set; }

        [Required]
        [StringLength(30)]
        [Column("SDESCRIPT", TypeName = "char(30)")]
        public string SDescript { get; set; }

        [Required]
        [Column("DCOMPDATE", TypeName = "date")]
        public DateTime DCompDate { get; set; } = DateTime.Now;

        [Required]
        [Column("NSTATREGT")]
        public int NStatRegt { get; set; }  // 0 = Inactivo, 1 = Activo

        [Column("NUSERCODE")]
        public int? NUserCode { get; set; }

        [ForeignKey("NUserCode")]
        public virtual Usuario Usuario { get; set; }
    }
}
