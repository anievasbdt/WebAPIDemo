using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Nacionality
    {
        [Key]
        [Column("NNATIONALITY")]
        public int NNationality { get; set; }

        [Required]
        [Column("DCOMPDATE", TypeName = "date")]
        public DateTime DCompDate { get; set; } = DateTime.Now;

        [StringLength(30)]
        [Column("SDESCRIPT", TypeName = "char(30)")]
        public string? SDescript { get; set; }

        [StringLength(12)]
        [Column("SSHORT_DES", TypeName = "char(30)")]
        public string? SShort_Des { get; set; }

        [Required]
        [Column("NSTATREGT")]
        public int NStatRegt { get; set; }  // 0 = Inactivo, 1 = Activo

        [Column("NUSERCODE")]
        public int? NUserCode { get; set; }

        [ForeignKey("NUserCode")]
        public virtual Usuario Usuario { get; set; }
    }
}
