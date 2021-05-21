using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TredeWeb.DataLayer
{
    public partial class WareHouses
    {
        public WareHouses()
        {
            Inventories = new HashSet<Inventories>();
            InverseParentWareHouseNavigation = new HashSet<WareHouses>();
            ItemToWareHouses = new HashSet<ItemToWareHouses>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(24)]
        public string Code { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [StringLength(50)]
        public string WareHouseName { get; set; }
        public int? ParentWareHouse { get; set; }
        public int? Section { get; set; }
        public bool? IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [ForeignKey(nameof(ParentWareHouse))]
        [InverseProperty(nameof(WareHouses.InverseParentWareHouseNavigation))]
        public virtual WareHouses ParentWareHouseNavigation { get; set; }
        [ForeignKey(nameof(Section))]
        [InverseProperty(nameof(Sections.WareHouses))]
        public virtual Sections SectionNavigation { get; set; }
        [InverseProperty("WareHouseNavigation")]
        public virtual ICollection<Inventories> Inventories { get; set; }
        [InverseProperty(nameof(WareHouses.ParentWareHouseNavigation))]
        public virtual ICollection<WareHouses> InverseParentWareHouseNavigation { get; set; }
        [InverseProperty("Warehouse")]
        public virtual ICollection<ItemToWareHouses> ItemToWareHouses { get; set; }
    }
}
