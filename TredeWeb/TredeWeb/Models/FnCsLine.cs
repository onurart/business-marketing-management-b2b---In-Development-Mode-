using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TredeWeb.Models
{
    public class FnCsLine
    {


        [Key]
        public int Id { get; set; }
        public int? AccountRef { get; set; }
        [Column(TypeName = "money")]
        public decimal? Amount { get; set; }
        [StringLength(100)]
        public string BankAccount { get; set; }
        [StringLength(100)]
        public string BankBranch { get; set; }
        [StringLength(100)]
        public string BankName { get; set; }
        [StringLength(100)]
        public string BillAdres { get; set; }
        [StringLength(100)]
        public string CheckNumber { get; set; }
        [Column(TypeName = "money")]
        public decimal? Cost { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        public int? FicheRef { get; set; }
        public int? FinanceLineRef { get; set; }
        [StringLength(100)]
        public string IndoorSement { get; set; }
        public bool? IsCostInclude { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LineDate { get; set; }
        public int? LineNr { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? MaturityDate { get; set; }
        [StringLength(100)]
        public string Obligor { get; set; }
        [StringLength(100)]
        public string PaymentPlace { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        public int? CostRef { get; set; }
        public int? Currency { get; set; }
        public bool? IsComplete { get; set; }
        public int? Sign { get; set; }
        public bool? IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [ForeignKey(nameof(AccountRef))]
        [InverseProperty(nameof(DataLayer.Accounts.FnCsLines))]
        public virtual DataLayer.Accounts AccountRefNavigation { get; set; }
        [ForeignKey(nameof(CostRef))]
        [InverseProperty("FnCsLines")]
        public virtual DataLayer.Costs CostRefNavigation { get; set; }
        [ForeignKey(nameof(Currency))]
        [InverseProperty(nameof(DataLayer.Currencies.FnCsLines))]
        public virtual DataLayer.Currencies CurrencyNavigation { get; set; }
        [ForeignKey(nameof(FicheRef))]
        [InverseProperty(nameof(DataLayer.FnCsFiches.FnCsLines))]
        public virtual DataLayer.FnCsFiches FicheRefNavigation { get; set; }
        [ForeignKey(nameof(FinanceLineRef))]
        [InverseProperty(nameof(DataLayer.FnFicheLines.FnCsLines))]
        public virtual DataLayer.FnFicheLines FinanceLineRefNavigation { get; set; }
        [InverseProperty("CsRefNavigation")]
        public virtual ICollection<DataLayer.Costs> Costs { get; set; }
    }
}
