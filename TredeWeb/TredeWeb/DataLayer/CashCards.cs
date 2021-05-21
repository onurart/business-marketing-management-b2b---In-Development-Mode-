using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TredeWeb.DataLayer
{
    public partial class CashCards
    {
        public CashCards()
        {
            FnCashFiches = new HashSet<FnCashFiches>();
            FnFicheLines = new HashSet<FnFicheLines>();
            InverseParentCardNavigation = new HashSet<CashCards>();
        }

        [Key]
        public int Id { get; set; }
        public int? ParentCard { get; set; }
        [StringLength(100)]
        public string Code { get; set; }
        [StringLength(100)]
        public string CardName { get; set; }
        public int? AccountRef { get; set; }
        public int? OwnerRef { get; set; }
        public bool? IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [ForeignKey(nameof(AccountRef))]
        [InverseProperty(nameof(Accounts.CashCards))]
        public virtual Accounts AccountRefNavigation { get; set; }
        [ForeignKey(nameof(OwnerRef))]
        [InverseProperty(nameof(Users.CashCards))]
        public virtual Users OwnerRefNavigation { get; set; }
        [ForeignKey(nameof(ParentCard))]
        [InverseProperty(nameof(CashCards.InverseParentCardNavigation))]
        public virtual CashCards ParentCardNavigation { get; set; }
        [InverseProperty("CardRefNavigation")]
        public virtual ICollection<FnCashFiches> FnCashFiches { get; set; }
        [InverseProperty("CardRefNavigation")]
        public virtual ICollection<FnFicheLines> FnFicheLines { get; set; }
        [InverseProperty(nameof(CashCards.ParentCardNavigation))]
        public virtual ICollection<CashCards> InverseParentCardNavigation { get; set; }
    }
}
