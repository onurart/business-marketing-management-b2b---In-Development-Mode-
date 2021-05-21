using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TredeWeb.DataLayer
{
    public partial class Costs
    {
        public Costs()
        {
            FnBankLines = new HashSet<FnBankLines>();
            FnCashLines = new HashSet<FnCashLines>();
            FnCreditCardLines = new HashSet<FnCreditCardLines>();
            FnCsLines = new HashSet<FnCsLines>();
            FnFicheLines = new HashSet<FnFicheLines>();
        }

        [Key]
        public int Id { get; set; }
        public int? Type { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [StringLength(100)]
        public string Number { get; set; }
        public int? OwnerRef { get; set; }
        public double? CostTotal { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CostDate { get; set; }
        public int? BankRef { get; set; }
        public int? CsRef { get; set; }
        public int? CashRef { get; set; }
        public int? AccountRef { get; set; }
        public bool? IsApproved { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ApproveDate { get; set; }
        public bool? IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public int? CreditCardRef { get; set; }

        [ForeignKey(nameof(AccountRef))]
        [InverseProperty(nameof(Accounts.Costs))]
        public virtual Accounts AccountRefNavigation { get; set; }
        [ForeignKey(nameof(BankRef))]
        [InverseProperty("Costs")]
        public virtual FnBankLines BankRefNavigation { get; set; }
        [ForeignKey(nameof(CreditCardRef))]
        [InverseProperty("Costs")]
        public virtual FnCreditCardLines CreditCardRefNavigation { get; set; }
        [ForeignKey(nameof(CsRef))]
        [InverseProperty("Costs")]
        public virtual FnCsLines CsRefNavigation { get; set; }
        [ForeignKey(nameof(OwnerRef))]
        [InverseProperty(nameof(Users.Costs))]
        public virtual Users OwnerRefNavigation { get; set; }
        [InverseProperty("CostRefNavigation")]
        public virtual ICollection<FnBankLines> FnBankLines { get; set; }
        [InverseProperty("CostRefNavigation")]
        public virtual ICollection<FnCashLines> FnCashLines { get; set; }
        [InverseProperty("CostRefNavigation")]
        public virtual ICollection<FnCreditCardLines> FnCreditCardLines { get; set; }
        [InverseProperty("CostRefNavigation")]
        public virtual ICollection<FnCsLines> FnCsLines { get; set; }
        [InverseProperty("CostRefNavigation")]
        public virtual ICollection<FnFicheLines> FnFicheLines { get; set; }
    }
}
