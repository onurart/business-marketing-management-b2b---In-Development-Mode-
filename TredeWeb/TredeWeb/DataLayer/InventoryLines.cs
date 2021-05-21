using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TredeWeb.DataLayer
{
    public partial class InventoryLines
    {
        [Key]
        public int Id { get; set; }
        public int? StockFicheRef { get; set; }
        public bool? IsChange { get; set; }
        public string LineGuid { get; set; }
        public int? OwnerRef { get; set; }
        public int? AccountRef { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Amount { get; set; }
        public int? DiscountType { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? DiscountValue { get; set; }
        public bool? IsCancelled { get; set; }
        public bool? IsDiscounted { get; set; }
        public int? ItemRef { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedUser { get; set; }
        public int? MoveType { get; set; }
        [Column(TypeName = "money")]
        public decimal? Price { get; set; }
        public int? SalesmanRef { get; set; }
        public int? Tax { get; set; }
        public int? LineNr { get; set; }
        public int? CostTax1 { get; set; }
        public int? CostTax2 { get; set; }
        public int? CostTax3 { get; set; }
        public int? CurrencyRef { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? MinimumStockLevel { get; set; }
        public bool? IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public int? UnitRef { get; set; }
        public int? UnitLineRef { get; set; }

        [ForeignKey(nameof(AccountRef))]
        [InverseProperty(nameof(Accounts.InventoryLines))]
        public virtual Accounts AccountRefNavigation { get; set; }
        [ForeignKey(nameof(CurrencyRef))]
        [InverseProperty(nameof(Currencies.InventoryLines))]
        public virtual Currencies CurrencyRefNavigation { get; set; }
        [ForeignKey(nameof(ItemRef))]
        [InverseProperty(nameof(Items.InventoryLines))]
        public virtual Items ItemRefNavigation { get; set; }
        [ForeignKey(nameof(OwnerRef))]
        [InverseProperty(nameof(Users.InventoryLines))]
        public virtual Users OwnerRefNavigation { get; set; }
        [ForeignKey(nameof(StockFicheRef))]
        [InverseProperty(nameof(Inventories.InventoryLines))]
        public virtual Inventories StockFicheRefNavigation { get; set; }
        [ForeignKey(nameof(UnitLineRef))]
        [InverseProperty(nameof(UnitLines.InventoryLines))]
        public virtual UnitLines UnitLineRefNavigation { get; set; }
        [ForeignKey(nameof(UnitRef))]
        [InverseProperty(nameof(Units.InventoryLines))]
        public virtual Units UnitRefNavigation { get; set; }
    }
}
