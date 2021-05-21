using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TredeWeb.DataLayer;

namespace TredeWeb.Models
{
    public class FnCashLine
    {
        public FnCashLine()
        {
            FnFicheLines = new HashSet<FnFicheLines>();
        }

        [Key]
        public int Id { get; set; }
        public int? FinanceLineRef { get; set; }
        public int? FicheRef { get; set; }
        public bool? IsCostInclude { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LineDate { get; set; }
        public int? LineNr { get; set; }
        public int? Sign { get; set; }
        [Column(TypeName = "money")]
        public decimal? Total { get; set; }
        [Column(TypeName = "money")]
        public decimal? Cost { get; set; }
        public int? Currency { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        public int? CostRef { get; set; }
        public bool? IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public int? AccountRef { get; set; }

        [ForeignKey(nameof(AccountRef))]
        [InverseProperty(nameof(DataLayer.Accounts.FnCashLines))]
        public virtual DataLayer.Accounts AccountRefNavigation { get; set; }
        [ForeignKey(nameof(CostRef))]
        [InverseProperty(nameof(DataLayer.Costs.FnCashLines))]
        public virtual DataLayer.Costs CostRefNavigation { get; set; }
        [ForeignKey(nameof(Currency))]
        [InverseProperty(nameof(DataLayer.Currencies.FnCashLines))]
        public virtual DataLayer.Currencies CurrencyNavigation { get; set; }
        [ForeignKey(nameof(FicheRef))]
        [InverseProperty(nameof(FnCashFich.FnCashLines))]
        public virtual FnCashFich FicheRefNavigation { get; set; }
        [ForeignKey(nameof(FinanceLineRef))]
        [InverseProperty("FnCashLines")]
        public virtual FnFicheLines FinanceLineRefNavigation { get; set; }
        [InverseProperty("CashRefNavigation")]
        public virtual ICollection<FnFicheLines> FnFicheLines { get; set; }
    }
}
