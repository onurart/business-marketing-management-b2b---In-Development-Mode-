using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TredeWeb.DataLayer
{
    public partial class FnBarterLines
    {
        public FnBarterLines()
        {
            FnFicheLines = new HashSet<FnFicheLines>();
        }

        [Key]
        public int Id { get; set; }
        public int? FinanceLineRef { get; set; }
        public int? FicheRef { get; set; }
        public int? AccountRef { get; set; }
        public int? Currency { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LineDate { get; set; }
        public int? LineNr { get; set; }
        public short? Sign { get; set; }
        [Column(TypeName = "money")]
        public decimal? Amount { get; set; }
        public int? Type { get; set; }
        public bool? IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [ForeignKey(nameof(AccountRef))]
        [InverseProperty(nameof(Accounts.FnBarterLines))]
        public virtual Accounts AccountRefNavigation { get; set; }
        [ForeignKey(nameof(Currency))]
        [InverseProperty(nameof(Currencies.FnBarterLines))]
        public virtual Currencies CurrencyNavigation { get; set; }
        [ForeignKey(nameof(FicheRef))]
        [InverseProperty(nameof(FnBarterFiches.FnBarterLines))]
        public virtual FnBarterFiches FicheRefNavigation { get; set; }
        [ForeignKey(nameof(FinanceLineRef))]
        [InverseProperty("FnBarterLines")]
        public virtual FnFicheLines FinanceLineRefNavigation { get; set; }
        [InverseProperty("BarterRefNavigation")]
        public virtual ICollection<FnFicheLines> FnFicheLines { get; set; }
    }
}
