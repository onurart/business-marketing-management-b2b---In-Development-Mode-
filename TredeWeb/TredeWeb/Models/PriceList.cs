using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TredeWeb.DataLayer;

namespace TredeWeb.Models
{
    public class PriceList
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Discount { get; set; }
        public int? DiscountType { get; set; }
        [Column(TypeName = "money")]
        public decimal? DiscountValue { get; set; }
        public bool? IsDefault { get; set; }
        public bool? IsDiscount { get; set; }
        public int? OwnerRef { get; set; }
        [Column(TypeName = "money")]
        public decimal? Price { get; set; }
        [StringLength(100)]
        public string Specode { get; set; }
        [Column(TypeName = "money")]
        public decimal? Tax { get; set; }
        public int? CurrencyRef { get; set; }
        public bool? IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public int? ItemRef { get; set; }

        [ForeignKey(nameof(CurrencyRef))]


        [InverseProperty(nameof(Items.PriceLists))]
        public virtual Items ItemRefNavigation { get; set; }
        [ForeignKey(nameof(OwnerRef))]
        [InverseProperty(nameof(Users.PriceLists))]
        public virtual Users OwnerRefNavigation { get; set; }
    }
}
