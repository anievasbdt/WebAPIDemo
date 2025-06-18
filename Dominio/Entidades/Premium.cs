using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    public class Premium
    {
        [Key, Column("NBRANCH")]
        public int NBranch { get; set; }

        [Key, Column("NPRODUCT")]
        public int NProduct { get; set; }

        [Key, Column("NPOLICY")]
        public int NPolicy { get; set; }

        [Key, Column("NRECEIPT")]
        public int NReceipt { get; set; }

        [Required]
        [Column("DEFFECDATE", TypeName = "date")]
        public DateTime DEffecDate { get; set; }

        [Required]
        [Column("DISSUEDAT", TypeName = "date")]
        public DateTime DIssueDat { get; set; }

        [Required]
        [Column("DEXPIRDAT", TypeName = "date")]
        public DateTime DExpirDat { get; set; }

        [Required]
        [Column("NWAY_PAY")]
        public int NWayPay { get; set; }

        [Required]
        [Column("NPREMIUM")]
        public decimal NPremium { get; set; }

        [Required]
        [Column("NBALANCE")]
        public decimal NBalance { get; set; }

        [Required]
        [Column("NSTATUS_PRE")]
        public int NStatusPre { get; set; }

        [Column("NSTATUS_PAY")]
        public int? NStatusPay { get; set; }

        [Column("DNULLDATE", TypeName = "date")]
        public DateTime? DNullDate { get; set; }

        [Column("NNULLCODE")]
        public int? NNullCode { get; set; }

        [Column("NUSERCODE")]
        public int? NUserCode { get; set; }

        // Relaciones
        [ForeignKey("NWayPay")]
        public virtual Way_pay WayPay { get; set; }

        [ForeignKey("NStatusPre")]
        public virtual StatusPre StatusPre { get; set; }

        [ForeignKey("NStatusPay")]
        public virtual StatusPay? StatusPay { get; set; }

        [ForeignKey("NNullCode")]
        public virtual NMPremium NullCode { get; set; }

        [ForeignKey("NUserCode")]
        public virtual Usuario Usuario { get; set; }

        [ForeignKey("NBranch, NProduct")]
        public virtual ProductMaster ProductMaster { get; set; }

        [ForeignKey("NBranch, NProduct, NPolicy")]
        public virtual Poliza Poliza { get; set; }
    }
}
