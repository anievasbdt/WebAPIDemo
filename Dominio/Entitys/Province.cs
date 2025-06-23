using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    public class Province
    {
        [Key]
        [Column("NPROVINCE")]
        public int NProvince { get; set; }

        [Required]
        [StringLength(30)]
        [Column("SDESCRIPT", TypeName = "char(30)")]
        public string SDescript { get; set; }

        [Required]
        [Column("DCOMPDATE", TypeName = "date")]
        public DateTime DCompDate { get; set; } = DateTime.Now;

        [Column("NUSERCODE")]
        public int? NUserCode { get; set; }

        [ForeignKey("NUserCode")]
        public virtual Usuario Usuario { get; set; }

    }
}