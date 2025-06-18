using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    public class Municipality
    {
        [Key]
        [Column("NMUNICIPALITY")]
        public int NMunicipality { get; set; }

        [StringLength(30)]
        [Column("SDESCRIPT", TypeName = "char(30)")]
        public string? SDescript { get; set; }

        [Column("NPROVINCE")]
        public int NProvince { get; set; }

        [ForeignKey("NProvince")]
        public virtual Province Province { get; set; }

    }
}