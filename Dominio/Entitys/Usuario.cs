using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Usuario
    {
        [Key]
        [Column("NUSERCODE")]
        public int NUsercode { get; set; }

        [Required]
        [StringLength(14)]
        [Column("SINITIALS", TypeName = "char(12)")]
        public string SInitials { get; set; }

        [Required]
        [Column("NSTATREGT")]
        public int NStatRegt { get; set; }  // 0 = Inactivo, 1 = Activo
    }
}
