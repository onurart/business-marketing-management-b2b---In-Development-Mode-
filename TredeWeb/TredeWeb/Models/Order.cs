using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TredeWeb.DataLayer;

namespace TredeWeb.Models
{
    public class Order
    {
        public Order()
        {
            FnFiches = new HashSet<FnFiches>();
            OrderLines = new HashSet<OrderLines>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string SrcName { get; set; }
        [StringLength(100)]
        public string OrderSessionId { get; set; }
        public bool? IsProcess { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ApproveDate { get; set; }
        public int? BasketRef { get; set; }
        public int? AccountRef { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        public int? Coupon { get; set; }
        public int? FinanceRef { get; set; }
        public int? DeliveryAddress { get; set; }
        [StringLength(100)]
        public string DeliveryCompany { get; set; }
        [Column(TypeName = "money")]
        public decimal? Discount { get; set; }
        public int? DiscountType { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? OrderDiscount { get; set; }
        [Column(TypeName = "money")]
        public decimal? FicheTotal { get; set; }
        public int? InvoiceAddress { get; set; }
        public bool? IsApproved { get; set; }
        public bool? IsCharged { get; set; }
        public bool? IsDiscount { get; set; }
        public bool? IsGiftPackage { get; set; }
        public bool? IsWholeSale { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OrderDate { get; set; }
        [StringLength(100)]
        public string OrderNote { get; set; }
        public int? OrderStatus { get; set; }
        public int? OrderStyle { get; set; }
        [Column(TypeName = "money")]
        public decimal? OrderTotal { get; set; }
        public int? OwnerRef { get; set; }
        public int? PaymentType { get; set; }
        public bool? IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [ForeignKey(nameof(Coupon))]
        [InverseProperty(nameof(CouponCode.Orders))]
        public virtual CouponCode CouponNavigation { get; set; }
        [ForeignKey(nameof(FinanceRef))]
        [InverseProperty("Orders")]
        public virtual FnFiches FinanceRefNavigation { get; set; }
        [ForeignKey(nameof(OwnerRef))]
        [InverseProperty(nameof(Users.Orders))]
        public virtual Users OwnerRefNavigation { get; set; }
        [ForeignKey(nameof(PaymentType))]
        [InverseProperty(nameof(PaymentTypes.Orders))]
        public virtual PaymentTypes PaymentTypeNavigation { get; set; }
        [InverseProperty("OrderRefNavigation")]
        public virtual ICollection<FnFiches> FnFiches { get; set; }
        [InverseProperty("OrderRefNavigation")]
        public virtual ICollection<OrderLines> OrderLines { get; set; }
    }
}
