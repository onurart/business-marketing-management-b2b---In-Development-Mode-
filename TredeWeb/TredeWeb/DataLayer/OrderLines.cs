using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TredeWeb.DataLayer
{
    public partial class OrderLines
    {
        public OrderLines()
        {
            FnFicheLines = new HashSet<FnFicheLines>();
        }

        [Key]
        public int Id { get; set; }
        public int? OrderRef { get; set; }
        public int? LineId { get; set; }
        public int? ItemRef { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Amount { get; set; }
        public int? Vat { get; set; }
        [Column(TypeName = "money")]
        public decimal? Price { get; set; }
        [Column(TypeName = "money")]
        public decimal? LineTotal { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public bool? IsActive { get; set; }
        public int? UnitRef { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        public int? UnitLineRef { get; set; }
        public int? CurrencyRef { get; set; }
        public int? FinanceLineRef { get; set; }

        [ForeignKey(nameof(CurrencyRef))]
        [InverseProperty(nameof(Currencies.OrderLines))]
        public virtual Currencies CurrencyRefNavigation { get; set; }
        [ForeignKey(nameof(FinanceLineRef))]
        [InverseProperty("OrderLines")]
        public virtual FnFicheLines FinanceLineRefNavigation { get; set; }
        [ForeignKey(nameof(ItemRef))]
        [InverseProperty(nameof(Items.OrderLines))]
        public virtual Items ItemRefNavigation { get; set; }
        [ForeignKey(nameof(OrderRef))]
        [InverseProperty(nameof(Orders.OrderLines))]
        public virtual Orders OrderRefNavigation { get; set; }
        [ForeignKey(nameof(UnitLineRef))]
        [InverseProperty(nameof(UnitLines.OrderLines))]
        public virtual UnitLines UnitLineRefNavigation { get; set; }
        [ForeignKey(nameof(UnitRef))]
        [InverseProperty(nameof(Units.OrderLines))]
        public virtual Units UnitRefNavigation { get; set; }
        [InverseProperty("OrderRefNavigation")]
        public virtual ICollection<FnFicheLines> FnFicheLines { get; set; }
    }
}
