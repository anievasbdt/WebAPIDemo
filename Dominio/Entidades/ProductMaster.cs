using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    public class ProductMaster
    {
        [Key, Column("NBRANCH", Order = 0)]
        [ForeignKey(nameof(Branch))]
        public int NBranch { get; set; }

        [Key, Column("NPRODUCT", Order = 1)]
        public int NProduct { get; set; }

        [Required]
        [StringLength(30)]
        [Column("SDESCRIPT", TypeName = "char(30)")]
        public string SDescript { get; set; }

        [StringLength(12)]
        [Column("SSHORT_DES", TypeName = "char(12)")]
        public string? SShortDes { get; set; }

        [Required]
        [Column("DCOMPDATE", TypeName = "date")]
        public DateTime DCompDate { get; set; } = DateTime.Now;

        [Required]
        [Column("NSTATREGT")]
        public int NStatRegt { get; set; }  // 0 = Inactivo, 1 = Activo

        [Column("NUSERCODE")]
        public int? NUserCode { get; set; }

        // Relaciones

        //[ForeignKey("NBranch")]
        public virtual Branch Branch { get; set; }

        [ForeignKey("NUserCode")]
        public virtual Usuario Usuario { get; set; }
    }
}
