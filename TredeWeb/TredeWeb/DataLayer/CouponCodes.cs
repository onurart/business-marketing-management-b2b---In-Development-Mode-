using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TredeWeb.DataLayer
{
    public partial class CouponCodes
    {
        public CouponCodes()
        {
            Orders = new HashSet<Orders>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(24)]
        public string Code { get; set; }
        public bool? CouponType { get; set; }
        [Column(TypeName = "money")]
        public decimal? CouponValue { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DueDate { get; set; }
        public int? OwnerRef { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public bool? IsActive { get; set; }

        [ForeignKey(nameof(OwnerRef))]
        [InverseProperty(nameof(Users.CouponCodes))]
        public virtual Users OwnerRefNavigation { get; set; }
        [InverseProperty("CouponNavigation")]
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
