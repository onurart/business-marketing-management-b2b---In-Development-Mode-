using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TredeWeb.DataLayer
{
    public partial class Units
    {
        public Units()
        {
            InventoryLines = new HashSet<InventoryLines>();
            InverseParentUnitSetNavigation = new HashSet<Units>();
            OrderLines = new HashSet<OrderLines>();
            UnitLines = new HashSet<UnitLines>();
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
        public virtual ICollection<UnitLines> UnitLines { get; set; }
    }
}
