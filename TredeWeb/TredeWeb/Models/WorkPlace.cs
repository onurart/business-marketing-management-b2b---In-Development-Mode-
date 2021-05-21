using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TredeWeb.DataLayer;

namespace TredeWeb.Models
{
    public class WorkPlace
    {
        public WorkPlace()
        {
            Inventories = new HashSet<Inventories>();
            InverseParentWorkPlaceNavigation = new HashSet<WorkPlaces>();
            Sections = new HashSet<Section>();
        }
        [Key]
        public int Id { get; set; }
        [StringLength(24)]
        public string Code { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [StringLength(50)]
        public string WorkPlaceName { get; set; }
        public int? ParentWorkPlace { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public bool? IsActive { get; set; }

        [ForeignKey(nameof(ParentWorkPlace))]
        [InverseProperty(nameof(WorkPlaces.InverseParentWorkPlaceNavigation))]
        public virtual WorkPlaces ParentWorkPlaceNavigation { get; set; }
        [InverseProperty("WorkPlaceNavigation")]
        public virtual ICollection<Inventories> Inventories { get; set; }
        [InverseProperty(nameof(WorkPlaces.ParentWorkPlaceNavigation))]
        public virtual ICollection<WorkPlaces> InverseParentWorkPlaceNavigation { get; set; }
        [InverseProperty("WorkPlaceNavigation")]
        public virtual ICollection<Section> Sections { get; set; }
    }
}
