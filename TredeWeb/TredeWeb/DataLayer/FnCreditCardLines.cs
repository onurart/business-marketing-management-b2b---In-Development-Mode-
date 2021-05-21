using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TredeWeb.DataLayer
{
    public partial class FnCreditCardLines
    {
        public FnCreditCardLines()
        {
            Costs = new HashSet<Costs>();
        }

        [Key]
        public int Id { get; set; }
        public int? FinanceLineRef { get; set; }
        public int? FicheRef { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LineDate { get; set; }
        public int? LineNr { get; set; }
        public int? Sign { get; set; }
        [Column(TypeName = "money")]
        public decimal? Total { get; set; }
        public int? Currency { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        public int? AccountRef { get; set; }
        [StringLength(100)]
        public string CardNo { get; set; }
        [StringLength(100)]
        public string PosNo { get; set; }
        public bool? IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        [Column(TypeName = "money")]
        public decimal? Cost { get; set; }
        public int? CostRef { get; set; }

        [ForeignKey(nameof(AccountRef))]
        [InverseProperty(nameof(Accounts.FnCreditCardLines))]
        public virtual Accounts AccountRefNavigation { get; set; }
        [ForeignKey(nameof(CostRef))]
        [InverseProperty("FnCreditCardLines")]
        public virtual Costs CostRefNavigation { get; set; }
        [ForeignKey(nameof(Currency))]
        [InverseProperty(nameof(Currencies.FnCreditCardLines))]
        public virtual Currencies CurrencyNavigation { get; set; }
        [ForeignKey(nameof(FicheRef))]
        [InverseProperty(nameof(FnCreditCardFiches.FnCreditCardLines))]
        public virtual FnCreditCardFiches FicheRefNavigation { get; set; }
        [ForeignKey(nameof(FinanceLineRef))]
        [InverseProperty(nameof(FnFicheLines.FnCreditCardLines))]
        public virtual FnFicheLines FinanceLineRefNavigation { get; set; }
        [InverseProperty("CreditCardRefNavigation")]
        public virtual ICollection<Costs> Costs { get; set; }
    }
}
