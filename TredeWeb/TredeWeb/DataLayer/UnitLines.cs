using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TredeWeb.DataLayer
{
    public partial class UnitLines
    {
        public UnitLines()
        {
            InventoryLines = new HashSet<InventoryLines>();
            OrderLines = new HashSet<OrderLines>();
        }

        [Key]
        public int Id { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? ChildFactor { get; set; }
        [StringLength(24)]
        public string Code { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? MasterFactor { get; set; }
        public int? UnitRef { get; set; }
        public bool? IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [ForeignKey(nameof(UnitRef))]
        [InverseProperty(nameof(Units.UnitLines))]
        public virtual Units UnitRefNavigation { get; set; }
        [InverseProperty("UnitLineRefNavigation")]
        public virtual ICollection<InventoryLines> InventoryLines { get; set; }
        [InverseProperty("UnitLineRefNavigation")]
        public virtual ICollection<OrderLines> OrderLines { get; set; }
    }
}
