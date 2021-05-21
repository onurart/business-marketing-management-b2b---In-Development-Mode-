using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TredeWeb.DataLayer;

namespace TredeWeb.Models
{
    public class Role
    {
        public Role()
        {
            UserToRoles = new HashSet<UserToRoles>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string RoleName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public bool? IsActive { get; set; }

        [InverseProperty("Role")]
        public virtual ICollection<UserToRoles> UserToRoles { get; set; }
    }
}
