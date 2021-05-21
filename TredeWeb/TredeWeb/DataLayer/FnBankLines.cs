using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TredeWeb.DataLayer
{
    public partial class FnBankLines
    {
        public FnBankLines()
        {
            Costs = new HashSet<Costs>();
            FnFicheLines = new HashSet<FnFicheLines>();
        }

        [Key]
        public int Id { get; set; }
        public int? AccountRef { get; set; }
        [Column(TypeName = "money")]
        public decimal? Amount { get; set; }
        public int? BankAccountRef { get; set; }
        public int? BranchRef { get; set; }
        public int? BankCardRef { get; set; }
        [Column(TypeName = "money")]
        public decimal? Cost { get; set; }
        public int? Currency { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [StringLength(100)]
        public string DocumentNumber { get; set; }
        public int? FicheRef { get; set; }
        public bool? IsCostInclude { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LineDate { get; set; }
        public int? LineNr { get; set; }
        public int? Sign { get; set; }
        public int? Type { get; set; }
        public int? FinanceLineRef { get; set; }
        public int? CostRef { get; set; }
        public bool? IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [ForeignKey(nameof(AccountRef))]
        [InverseProperty(nameof(Accounts.FnBankLines))]
        public virtual Accounts AccountRefNavigation { get; set; }
        [ForeignKey(nameof(BankAccountRef))]
        [InverseProperty(nameof(BankAccounts.FnBankLines))]
        public virtual BankAccounts BankAccountRefNavigation { get; set; }
        [ForeignKey(nameof(BankCardRef))]
        [InverseProperty(nameof(BankCards.FnBankLines))]
        public virtual BankCards BankCardRefNavigation { get; set; }
        [ForeignKey(nameof(BranchRef))]
        [InverseProperty(nameof(BankBranches.FnBankLines))]
        public virtual BankBranches BranchRefNavigation { get; set; }
        [ForeignKey(nameof(CostRef))]
        [InverseProperty("FnBankLines")]
        public virtual Costs CostRefNavigation { get; set; }
        [ForeignKey(nameof(Currency))]
        [InverseProperty(nameof(Currencies.FnBankLines))]
        public virtual Currencies CurrencyNavigation { get; set; }
        [ForeignKey(nameof(FicheRef))]
        [InverseProperty(nameof(FnBankFiches.FnBankLines))]
        public virtual FnBankFiches FicheRefNavigation { get; set; }
        [ForeignKey(nameof(FinanceLineRef))]
        [InverseProperty("FnBankLines")]
        public virtual FnFicheLines FinanceLineRefNavigation { get; set; }
        [InverseProperty("BankRefNavigation")]
        public virtual ICollection<Costs> Costs { get; set; }
        [InverseProperty("BankRefNavigation")]
        public virtual ICollection<FnFicheLines> FnFicheLines { get; set; }
    }
}
