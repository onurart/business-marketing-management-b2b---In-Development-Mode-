using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TredeWeb.DataLayer;

namespace TredeWeb.Models
{
    public class ItemToWareHouse
    {
        [Key]
        public int ItemId { get; set; }
        [Key]
        public int WarehouseId { get; set; }

        [ForeignKey(nameof(ItemId))]
        [InverseProperty(nameof(Items.ItemToWareHouses))]
        public virtual Items Item { get; set; }
        [ForeignKey(nameof(WarehouseId))]
        [InverseProperty(nameof(WareHouses.ItemToWareHouses))]
        public virtual WareHouses Warehouse { get; set; }
    }
}
