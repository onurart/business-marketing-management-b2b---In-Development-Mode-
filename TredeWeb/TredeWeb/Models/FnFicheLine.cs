using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TredeWeb.DataLayer;

namespace TredeWeb.Models
{
    public class FnFicheLine
    {
        public FnFicheLine()
        {
            FnBankLines = new HashSet<DataLayer.FnBankLines>();
            FnCashLines = new HashSet<FnCashLines>();
            FnCreditCardLines = new HashSet<FnCreditCardLines>();
            FnCsLines = new HashSet<FnCsLines>();
            OrderLines = new HashSet<OrderLines>();
        }

        [Key]
        public int Id { get; set; }
        public int? Collect { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedUser { get; set; }
        public int? Currency { get; set; }
        public int? LineNr { get; set; }
        public int? FinanceRef { get; set; }
        [Column(TypeName = "money")]
        public decimal? Amount { get; set; }
        [Column(TypeName = "money")]
        public decimal? Tax { get; set; }
        [Column(TypeName = "money")]
        public decimal? VatBase { get; set; }
        [Column(TypeName = "money")]
        public decimal? Total { get; set; }
        public int? BankRef { get; set; }
        public int? BarterRef { get; set; }
        public int? CsRef { get; set; }
        public int? CashRef { get; set; }
        public int? CreditCardRef { get; set; }
        public int? Sign { get; set; }
        public int? ModulEnr { get; set; }
        public int? AccountRef { get; set; }
        [Column(TypeName = "money")]
        public decimal? Cost { get; set; }
        public int? CardRef { get; set; }
        public bool? IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public int? CostRef { get; set; }
        public int? OrderRef { get; set; }

        [ForeignKey(nameof(AccountRef))]
        [InverseProperty(nameof(DataLayer.Accounts.FnFicheLines))]
        public virtual Account AccountRefNavigation { get; set; }
        [ForeignKey(nameof(BankRef))]
        [InverseProperty("FnFicheLines")]
        public virtual DataLayer.FnBankLines BankRefNavigation { get; set; }

        [ForeignKey(nameof(CardRef))]
        [InverseProperty(nameof(DataLayer.CashCards.FnFicheLines))]
        public virtual DataLayer.CashCards CardRefNavigation { get; set; }
        [ForeignKey(nameof(CashRef))]
        [InverseProperty("FnFicheLines")]
        public virtual FnCashLines CashRefNavigation { get; set; }
        [ForeignKey(nameof(CostRef))]
        [InverseProperty(nameof(DataLayer.Costs.FnFicheLines))]
        public virtual DataLayer.Costs CostRefNavigation { get; set; }
        [ForeignKey(nameof(Currency))]
        [InverseProperty(nameof(DataLayer.Currencies.FnFicheLines))]
        public virtual DataLayer.Currencies CurrencyNavigation { get; set; }
        [ForeignKey(nameof(FinanceRef))]
        [InverseProperty(nameof(FnFiches.FnFicheLines))]
        public virtual FnFiches FinanceRefNavigation { get; set; }
        [ForeignKey(nameof(OrderRef))]
        [InverseProperty("FnFicheLines")]
        public virtual OrderLines OrderRefNavigation { get; set; }
        [InverseProperty("FinanceLineRefNavigation")]
        public virtual ICollection<DataLayer.FnBankLines> FnBankLines { get; set; }
        [InverseProperty("FinanceLineRefNavigation")]
        public virtual ICollection<FnCashLines> FnCashLines { get; set; }
        [InverseProperty("FinanceLineRefNavigation")]
        public virtual ICollection<FnCreditCardLines> FnCreditCardLines { get; set; }
        [InverseProperty("FinanceLineRefNavigation")]
        public virtual ICollection<FnCsLines> FnCsLines { get; set; }
        [InverseProperty("FinanceLineRefNavigation")]
        public virtual ICollection<OrderLines> OrderLines { get; set; }
    }
}
