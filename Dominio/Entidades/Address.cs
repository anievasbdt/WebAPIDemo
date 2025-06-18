using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    public class Address
    {
        // Claves primarias compuestas
        [Key]
        [Column("NRECOWNER", Order = 1)]
        public int NRecOwner { get; set; }

        [Key]
        [Column("SKEYADDRESS", Order = 2)]
        public int SKeyAddress { get; set; }

        [Key]
        [Column("DEFFECDATE", TypeName = "date", Order = 3)]
        public DateTime DeffecDate { get; set; }

        [Key]
        [Column("SINFOR", Order = 4)]
        public int SInfor { get; set; }

        // Otras columnas
        [Required]
        [Column("SSTREET", TypeName = "char(40)")]
        [StringLength(40)]
        public string SStreet { get; set; }

        [Required]
        [Column("NHEIGHT")]
        public int NHeight { get; set; }

        [Column("SBUILD", TypeName = "varchar2(10)")]
        [StringLength(10)]
        public string? SBuild { get; set; }

        [Column("NFLOOR")]
        public int? NFloor { get; set; }

        [Column("SDEPARTMENT", TypeName = "varchar2(10)")]
        [StringLength(10)]
        public string? SDepartment { get; set; }

        [Required]
        [Column("SZIP_CODE", TypeName = "char(60)")]
        [StringLength(60)]
        public string SZipCode { get; set; }

        [Column("SZONE", TypeName = "char(20)")]
        [StringLength(20)]
        public string? SZone { get; set; }

        [Required]
        [Column("NLOCAL")]
        public int NLocal { get; set; }

        [Required]
        [Column("NMUNICIPALITY")]
        public int NMunicipality { get; set; }

        [Required]
        [Column("NPROVINCE")]
        public int NProvince { get; set; }

        [Column("SE_MAIL", TypeName = "char(8)")]
        [StringLength(8)]
        public string? SE_Mail { get; set; }

        [Column("NBRANCH")]
        public int? NBranch { get; set; }

        [Column("NPRODUCT")]
        public int? NProduct { get; set; }

        [Column("NPOLICY")]
        public int? NPolicy { get; set; }

        [Column("SCLIENT", TypeName = "char(14)")]
        [StringLength(14)]
        public string? SClient { get; set; }

        [Required]
        [Column("DCOMPDATE", TypeName = "date")]
        public DateTime DCompDate { get; set; } = DateTime.Now; // Valor por defecto SYSDATE

        [Column("NUSERCODE")]
        public int? NUserCode { get; set; }

        // Relaciones de navegación
        [ForeignKey("NLocal")]
        public virtual TabLocat TabLocat { get; set; }

        [ForeignKey("NMunicipality")]
        public virtual Municipality Municipality { get; set; }

        [ForeignKey("NProvince")]
        public virtual Province Province { get; set; }

        [ForeignKey("NBranch, NProduct, NPolicy")]
        public virtual Poliza Poliza { get; set; }

        [ForeignKey("SClient")]
        public virtual Client Client { get; set; }

        [ForeignKey("NUserCode")]
        public virtual Usuario Usuario { get; set; }
    }
}