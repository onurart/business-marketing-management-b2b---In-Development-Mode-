using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TredeWeb.DataLayer;

namespace TredeWeb.Models
{
    public class Section
    {
        public Section()
        {
            Inventories = new HashSet<Inventories>();
            InverseParentSectionNavigation = new HashSet<Sections>();
            WareHouses = new HashSet<WareHouses>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(24)]
        public string Code { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [StringLength(50)]
        public string SectionName { get; set; }
        public int? ParentSection { get; set; }
        public int? WorkPlace { get; set; }
        public bool? IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreadtedDate { get; set; }

        [ForeignKey(nameof(ParentSection))]
        [InverseProperty(nameof(Sections.InverseParentSectionNavigation))]
        public virtual Sections ParentSectionNavigation { get; set; }
        [ForeignKey(nameof(WorkPlace))]
        [InverseProperty(nameof(WorkPlaces.Sections))]
        public virtual WorkPlaces WorkPlaceNavigation { get; set; }
        [InverseProperty("SectionNavigation")]
        public virtual ICollection<Inventories> Inventories { get; set; }
        [InverseProperty(nameof(Sections.ParentSectionNavigation))]
        public virtual ICollection<Sections> InverseParentSectionNavigation { get; set; }
        [InverseProperty("SectionNavigation")]
        public virtual ICollection<WareHouses> WareHouses { get; set; }
    }
}
