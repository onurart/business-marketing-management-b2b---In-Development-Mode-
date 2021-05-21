using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TredeWeb.DataLayer;

namespace TredeWeb.Models
{
    public class Item
    {
        public Item()
        {

            InventoryLines = new HashSet<InventoryLines>();
            ItemToCategories = new HashSet<ItemToCategories>();
            ItemToTags = new HashSet<ItemToTags>();
            ItemToVariants = new HashSet<ItemToVariants>();
            ItemToWareHouses = new HashSet<ItemToWareHouses>();
            OrderLines = new HashSet<OrderLines>();
            Pictures = new HashSet<Picture>();
            PriceLists = new HashSet<PriceLists>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(24)]
        public string Code { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "money")]
        public decimal? StockAmount { get; set; }
        public string Description { get; set; }
        public bool? IsCampaignItem { get; set; }
        public bool? IsCategoryItem { get; set; }
        public bool? IsDiscounted { get; set; }
        public bool? IsMainItem { get; set; }
        public bool? IsWebItem { get; set; }
        public bool? IsDealer { get; set; }
        public bool? IsQuickDelivery { get; set; }
        public bool? IsNewSeason { get; set; }
        public bool? IsStockTracking { get; set; }
        public int? Mark { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedUser { get; set; }
        public int? Owner { get; set; }
        [StringLength(24)]
        public string Specode { get; set; }
        public int? Type { get; set; }
        public bool? IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [ForeignKey(nameof(Mark))]
        [InverseProperty(nameof(Marks.Items))]
        public virtual Marks MarkNavigation { get; set; }
        [InverseProperty("ItemRefNavigation")]
        public virtual ICollection<InventoryLines> InventoryLines { get; set; }
        [InverseProperty("Item")]
        public virtual ICollection<ItemToCategories> ItemToCategories { get; set; }
        [InverseProperty("Item")]
        public virtual ICollection<ItemToTags> ItemToTags { get; set; }
        [InverseProperty("Item")]
        public virtual ICollection<ItemToVariants> ItemToVariants { get; set; }
        [InverseProperty("Item")]
        public virtual ICollection<ItemToWareHouses> ItemToWareHouses { get; set; }
        [InverseProperty("ItemRefNavigation")]
        public virtual ICollection<OrderLines> OrderLines { get; set; }
        [InverseProperty("ItemRefNavigation")]
        public virtual ICollection<Picture> Pictures { get; set; }
        [InverseProperty("ItemRefNavigation")]
        public virtual ICollection<PriceLists> PriceLists { get; set; }
    }
}
