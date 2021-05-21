using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TredeWeb.DataLayer;

namespace TredeWeb.Models
{
    public class FnFiche
    {
        public FnFiche()
        {
            FnBankFiches = new HashSet<FnBankFiches>();
            FnCashFiches = new HashSet<FnCashFich>();
            FnCreditCardFiches = new HashSet<FnCreditCardFiches>();
            FnCsFiches = new HashSet<FnCsFiches>();
            FnFicheLines = new HashSet<FnFicheLines>();
            Orders = new HashSet<Orders>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [StringLength(100)]
        public string FicheNo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedUser { get; set; }
        public int? Owner { get; set; }
        [Column(TypeName = "money")]
        public decimal? LineTotal { get; set; }
        public int? BankFicheRef { get; set; }
        public int? CashFicheRef { get; set; }
        public int? BillFicheRef { get; set; }
        public int? CheckFicheRef { get; set; }
        public int? CreditCardFicheRef { get; set; }
        public int? BarterFicheRef { get; set; }
        public bool? IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public int? OrderRef { get; set; }

        [ForeignKey(nameof(BankFicheRef))]
        [InverseProperty("FnFiches")]
        public virtual FnBankFiches BankFicheRefNavigation { get; set; }
        [ForeignKey(nameof(BarterFicheRef))]
        [InverseProperty("FnFiches")]
        public virtual FnBarterFiches BarterFicheRefNavigation { get; set; }
        [ForeignKey(nameof(CashFicheRef))]
        [InverseProperty("FnFiches")]
        public virtual FnCashFich CashFicheRefNavigation { get; set; }
        [ForeignKey(nameof(CreditCardFicheRef))]
        [InverseProperty("FnFiches")]
        public virtual FnCreditCardFiches CreditCardFicheRefNavigation { get; set; }
        [ForeignKey(nameof(OrderRef))]
        [InverseProperty("FnFiches")]
        public virtual Orders OrderRefNavigation { get; set; }
        [ForeignKey(nameof(Owner))]
        [InverseProperty(nameof(Users.FnFiches))]
        public virtual Users OwnerNavigation { get; set; }
        [InverseProperty("IdNavigation")]
        public virtual FnBarterFiches FnBarterFiches { get; set; }
        [InverseProperty("FinanceRefNavigation")]
        public virtual ICollection<FnBankFiches> FnBankFiches { get; set; }
        [InverseProperty("FinanceRefNavigation")]
        public virtual ICollection<FnCashFich> FnCashFiches { get; set; }
        [InverseProperty("FinanceRefNavigation")]
        public virtual ICollection<FnCreditCardFiches> FnCreditCardFiches { get; set; }
        [InverseProperty("FinanceRefNavigation")]
        public virtual ICollection<FnCsFiches> FnCsFiches { get; set; }
        [InverseProperty("FinanceRefNavigation")]
        public virtual ICollection<FnFicheLines> FnFicheLines { get; set; }
        [InverseProperty("FinanceRefNavigation")]
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
