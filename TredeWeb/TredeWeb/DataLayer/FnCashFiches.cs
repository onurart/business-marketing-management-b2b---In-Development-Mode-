using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TredeWeb.DataLayer
{
    public partial class FnCashFiches
    {
        public FnCashFiches()
        {
            FnCashLines = new HashSet<FnCashLines>();
            FnFiches = new HashSet<FnFiches>();
        }

        [Key]
        public int Id { get; set; }
        public int? FinanceRef { get; set; }
        public int? Owner { get; set; }
        public int? Type { get; set; }
        [StringLength(100)]
        public string Number { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FicheDate { get; set; }
        public bool? IsApproved { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ApproveDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ReceiptDate { get; set; }
        [StringLength(100)]
        public string ReceiptNo { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        public int? CardRef { get; set; }
        public bool? IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
        [Column(TypeName = "money")]
        public decimal? FicheTotal { get; set; }

        [ForeignKey(nameof(CardRef))]
        [InverseProperty(nameof(CashCards.FnCashFiches))]
        public virtual CashCards CardRefNavigation { get; set; }
        [ForeignKey(nameof(FinanceRef))]
        [InverseProperty("FnCashFiches")]
        public virtual FnFiches FinanceRefNavigation { get; set; }
        [ForeignKey(nameof(Owner))]
        [InverseProperty(nameof(Users.FnCashFiches))]
        public virtual Users OwnerNavigation { get; set; }
        [InverseProperty("FicheRefNavigation")]
        public virtual ICollection<FnCashLines> FnCashLines { get; set; }
        [InverseProperty("CashFicheRefNavigation")]
        public virtual ICollection<FnFiches> FnFiches { get; set; }
    }
}
