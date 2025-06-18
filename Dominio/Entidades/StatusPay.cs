using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    public class StatusPay
    {
        [Key]
        [Column("NSTATUS_PAY")]
        public int NStatusPay { get; set; }  

        [Required]
        [StringLength(30)]
        [Column("SDESCRIPT", TypeName = "char(30)")]
        public string SDescript { get; set; }

        [Required]
        [Column("DCOMPDATE", TypeName = "date")]
        public DateTime DCompDate { get; set; } = DateTime.Now;

        [Required]
        [Column("NSTATREGT")]
        public int NStatRegt { get; set; }  

        [Column("NUSERCODE")]
        public int? NUserCode { get; set; }

        [ForeignKey("NUserCode")]
        public virtual Usuario Usuario { get; set; }
    }
}
