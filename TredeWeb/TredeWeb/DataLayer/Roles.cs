using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TredeWeb.DataLayer
{
    public partial class Roles
    {
        public Roles()
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
