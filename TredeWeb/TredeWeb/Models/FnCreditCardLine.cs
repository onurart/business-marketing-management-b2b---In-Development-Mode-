using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TredeWeb.Models
{
    public class FnCreditCardLine
    {


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
        [InverseProperty(nameof(DataLayer.Accounts.FnCreditCardLines))]
        public virtual DataLayer.Accounts AccountRefNavigation { get; set; }
        [ForeignKey(nameof(CostRef))]
        [InverseProperty("FnCreditCardLines")]
        public virtual DataLayer.Costs CostRefNavigation { get; set; }
        [ForeignKey(nameof(Currency))]
        [InverseProperty(nameof(DataLayer.Currencies.FnCreditCardLines))]
        public virtual DataLayer.Currencies CurrencyNavigation { get; set; }
        [ForeignKey(nameof(FicheRef))]
        [InverseProperty(nameof(DataLayer.FnCreditCardFiches.FnCreditCardLines))]
        public virtual DataLayer.FnCreditCardFiches FicheRefNavigation { get; set; }
        [ForeignKey(nameof(FinanceLineRef))]
        [InverseProperty(nameof(DataLayer.FnFicheLines.FnCreditCardLines))]
        public virtual DataLayer.FnFicheLines FinanceLineRefNavigation { get; set; }
        [InverseProperty("CreditCardRefNavigation")]
        public virtual ICollection<DataLayer.Costs> Costs { get; set; }
    }
}
