using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TredeWeb.DataLayer
{
    public partial class Inventories
    {
        public Inventories()
        {
            InventoryLines = new HashSet<InventoryLines>();
        }

        [Key]
        public int Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FicheDate { get; set; }
        public double? FicheTotal { get; set; }
        [StringLength(100)]
        public string Number { get; set; }
        public int? OwnerRef { get; set; }
        public int? Section { get; set; }
        [StringLength(100)]
        public string Specode { get; set; }
        public int? WareHouse { get; set; }
        public int? WorkPlace { get; set; }
        public bool? IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [ForeignKey(nameof(OwnerRef))]
        [InverseProperty(nameof(Users.Inventories))]
        public virtual Users OwnerRefNavigation { get; set; }
        [ForeignKey(nameof(Section))]
        [InverseProperty(nameof(Sections.Inventories))]
        public virtual Sections SectionNavigation { get; set; }
        [ForeignKey(nameof(WareHouse))]
        [InverseProperty(nameof(WareHouses.Inventories))]
        public virtual WareHouses WareHouseNavigation { get; set; }
        [ForeignKey(nameof(WorkPlace))]
        [InverseProperty(nameof(WorkPlaces.Inventories))]
        public virtual WorkPlaces WorkPlaceNavigation { get; set; }
        [InverseProperty("StockFicheRefNavigation")]
        public virtual ICollection<InventoryLines> InventoryLines { get; set; }
    }
}
