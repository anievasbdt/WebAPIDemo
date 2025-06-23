using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    public class Client
    {
        [Key]
        [StringLength(14)]
        [Column("SCLIENT", TypeName = "char(14)")]
        public string SClient { get; set; }

        [Column("DBIRTHDAT", TypeName = "date")]
        public DateTime? DBirthDat { get; set; }

        [StringLength(20)]
        [Column("SFIRSTNAME", TypeName = "char(20)")]
        public string? SFirstName { get; set; }

        [StringLength(20)]
        [Column("SLASTNAME", TypeName = "char(20)")]
        public string? SLastName { get; set; }

        [StringLength(20)]
        [Column("SLASTNAME2", TypeName = "char(20)")]
        public string? SLastName2 { get; set; }

        [StringLength(14)]
        [Column("SCUIT", TypeName = "char(14)")]
        public string? SCuit { get; set; }

        [StringLength(20)]
        [Column("SLEGALNAME", TypeName = "char(20)")]
        public string? SLegalName { get; set; }

        [StringLength(64)]
        [Column("SCLIENAME", TypeName = "char(64)")]
        public string? SClieName { get; set; }

        [StringLength(1)]
        [Column("SSEXCLIEN", TypeName = "char(1)")]
        public string? SSexClien { get; set; }

        [Column("NNATIONALITY")]
        public int? NNationality { get; set; }

        [Required]
        [Column("NSTATREGT")]
        public int NStatRegt { get; set; }  // 0 = Inactivo, 1 = Activo

        [Required]
        [Column("DCOMPDATE", TypeName = "date")]
        public DateTime DCompDate { get; set; } = DateTime.Now;

        [Column("NUSERCODE")]
        public int? NUserCode { get; set; }



        [ForeignKey("SSexClien")]
        public virtual Sex Sex { get; set; }

        [ForeignKey("NUserCode")]
        public virtual Usuario Usuario { get; set; }

        [ForeignKey("NNationality")]
        public virtual Nacionality Nacionality { get; set; }

    }
}
