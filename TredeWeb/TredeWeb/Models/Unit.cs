using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TredeWeb.DataLayer;

namespace TredeWeb.Models
{
    public class Unit
    {
        public Unit()
        {
            InventoryLines = new HashSet<InventoryLines>();
            InverseParentUnitSetNavigation = new HashSet<Units>();
            OrderLines = new HashSet<OrderLines>();
            UnitLines = new HashSet<UnitLine>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        public bool? IsGeneral { get; set; }
        public bool? IsDefault { get; set; }
        [StringLength(24)]
        public string SetName { get; set; }
        public int? ParentUnitSet { get; set; }
        public int? Specode { get; set; }
        public bool? IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [ForeignKey(nameof(ParentUnitSet))]
        [InverseProperty(nameof(Units.InverseParentUnitSetNavigation))]
        public virtual Units ParentUnitSetNavigation { get; set; }
        [InverseProperty("UnitRefNavigation")]
        public virtual ICollection<InventoryLines> InventoryLines { get; set; }
        [InverseProperty(nameof(Units.ParentUnitSetNavigation))]
        public virtual ICollection<Units> InverseParentUnitSetNavigation { get; set; }
        [InverseProperty("UnitRefNavigation")]
        public virtual ICollection<OrderLines> OrderLines { get; set; }
        [InverseProperty("UnitRefNavigation")]
        public virtual ICollection<UnitLine> UnitLines { get; set; }
    }
}
