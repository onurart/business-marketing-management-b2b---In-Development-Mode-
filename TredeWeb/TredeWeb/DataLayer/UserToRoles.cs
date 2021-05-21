using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TredeWeb.DataLayer
{
    public partial class UserToRoles
    {
        [Key]
        public int RoleId { get; set; }
        [Key]
        public int UserId { get; set; }

        [ForeignKey(nameof(RoleId))]
        [InverseProperty(nameof(Roles.UserToRoles))]
        public virtual Roles Role { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(Users.UserToRoles))]
        public virtual Users User { get; set; }
    }
}
