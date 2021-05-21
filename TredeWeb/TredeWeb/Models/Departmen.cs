using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TredeWeb.DataLayer;

namespace TredeWeb.Models
{
    public class Departmen
    {
        public Departmen()
        {
            InverseParentDepartmentNavigation = new HashSet<Departments>();
            Positions = new HashSet<Positions>();
            Users = new HashSet<Users>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(24)]
        public string Code { get; set; }
        [StringLength(50)]
        public string DepartmentName { get; set; }
        public int? ParentDepartment { get; set; }
        public int? OwnerRef { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public bool? IsActive { get; set; }

        [ForeignKey(nameof(ParentDepartment))]
        [InverseProperty(nameof(Departments.InverseParentDepartmentNavigation))]
        public virtual Departments ParentDepartmentNavigation { get; set; }
        [InverseProperty(nameof(Departments.ParentDepartmentNavigation))]
        public virtual ICollection<Departments> InverseParentDepartmentNavigation { get; set; }
        [InverseProperty("DepartmentNavigation")]
        public virtual ICollection<Positions> Positions { get; set; }
        [InverseProperty("DepartmentNavigation")]
        public virtual ICollection<Users> Users { get; set; }
    }
}
