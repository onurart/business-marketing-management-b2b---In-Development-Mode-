using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TredeWeb.DataLayer;

namespace TredeWeb.Models
{
    public class Position
    {

        public Position()
        {
            Users = new HashSet<Users>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(24)]
        public string Code { get; set; }
        public int? Department { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(24)]
        public string Title { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public bool? IsActive { get; set; }

        [ForeignKey(nameof(Department))]
        [InverseProperty(nameof(Departments.Positions))]
        public virtual Departments DepartmentNavigation { get; set; }
        [InverseProperty("PositionNavigation")]
        public virtual ICollection<Users> Users { get; set; }
    }
}
