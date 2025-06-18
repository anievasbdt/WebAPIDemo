using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    public class PolizaHistory
    {
        [Key, Column("NBRANCH", Order = 0)]
        public int NBranch { get; set; }

        [Key, Column("NPRODUCT", Order = 1)]
        public int NProduct { get; set; }

        [Key, Column("NPOLICY", Order = 2)]
        public int NPolicy { get; set; }

        [Key, Column("NMOVMENT", Order = 3)]
        public int NMovment { get; set; }

        [Required]
        [StringLength(14)]
        [Column("SCLIENT", TypeName = "char(14)")]
        public string SClient { get; set; }

        [Required]
        [Column("DDATE_ORIGI", TypeName = "date")]
        public DateTime DDateOrigi { get; set; }

        [Required]
        [Column("DSTARTDATE", TypeName = "date")]
        public DateTime DStartDate { get; set; }

        [Required]
        [Column("DEXPIRDAT", TypeName = "date")]
        public DateTime DExpirDat { get; set; }

        [Required]
        [Column("NCAPITAL")]
        public decimal NCapital { get; set; }

        [Required]
        [Column("NWAY_PAY")]
        public int NWayPay { get; set; }

        [Required]
        [Column("DCOMPDATE", TypeName = "date")]
        public DateTime DCompDate { get; set; } = DateTime.Now;

        [Column("DNULLDATE", TypeName = "date")]
        public DateTime? DNullDate { get; set; }

        [Column("NNULLCODE")]
        public int? NNullCode { get; set; }

        [Column("NUSERCODE")]
        public int? NUserCode { get; set; }

        // Relaciones

        [ForeignKey(nameof(SClient))]
        public virtual Client Client { get; set; }

        [ForeignKey(nameof(NWayPay))]
        public virtual Way_pay WayPay { get; set; }

        [ForeignKey(nameof(NNullCode))]
        public virtual NMPoliza NullReason { get; set; }

        [ForeignKey(nameof(NUserCode))]
        public virtual Usuario Usuario { get; set; }

        [ForeignKey(nameof(NBranch))]
        public virtual Branch Branch { get; set; }

        [ForeignKey(nameof(NBranch) + "," + nameof(NProduct))]
        public virtual ProductMaster Product { get; set; }
    }
}
