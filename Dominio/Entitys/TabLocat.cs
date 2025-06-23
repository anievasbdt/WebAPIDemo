using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    public class TabLocat
    {
        [Key]
        [Column("NLOCAL")]
        public int NLocal { get; set; }  

        [Required]
        [StringLength(30)]
        [Column("SDESCRIPT", TypeName = "char(30)")]
        public string SDescript { get; set; }  

        [Required]
        [Column("NMUNICIPALITY")]
        public int NMunicipality { get; set; }  

        [ForeignKey("NMunicipality")]
        public virtual Municipality Municipality { get; set; }

        [Required]
        [Column("DCOMPDATE", TypeName = "date")]
        public DateTime DCompDate { get; set; } = DateTime.Now;

        [Column("NUSERCODE")]
        public int? NUserCode { get; set; }

        [ForeignKey("NUserCode")]
        public virtual Usuario Usuario { get; set; }
    }
}
