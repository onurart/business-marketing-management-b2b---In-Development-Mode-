using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TredeWeb.DataLayer
{
    public partial class Currencies
    {
        public Currencies()
        {
            FnBankLines = new HashSet<FnBankLines>();
            FnBarterLines = new HashSet<FnBarterLines>();
            FnCashLines = new HashSet<FnCashLines>();
            FnCreditCardLines = new HashSet<FnCreditCardLines>();
            FnCsLines = new HashSet<FnCsLines>();
            FnFicheLines = new HashSet<FnFicheLines>();
            InventoryLines = new HashSet<InventoryLines>();
            OrderLines = new HashSet<OrderLines>();
            PriceLists = new HashSet<PriceLists>();
            Users = new HashSet<Users>();
        }

        [Key]
        public int Id { get; set; }
        public int? CurrType { get; set; }
        public double? CurrValue { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CurrDate { get; set; }
        public bool? IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [InverseProperty("CurrencyNavigation")]
        public virtual ICollection<FnBankLines> FnBankLines { get; set; }
        [InverseProperty("CurrencyNavigation")]
        public virtual ICollection<FnBarterLines> FnBarterLines { get; set; }
        [InverseProperty("CurrencyNavigation")]
        public virtual ICollection<FnCashLines> FnCashLines { get; set; }
        [InverseProperty("CurrencyNavigation")]
        public virtual ICollection<FnCreditCardLines> FnCreditCardLines { get; set; }
        [InverseProperty("CurrencyNavigation")]
        public virtual ICollection<FnCsLines> FnCsLines { get; set; }
        [InverseProperty("CurrencyNavigation")]
        public virtual ICollection<FnFicheLines> FnFicheLines { get; set; }
        [InverseProperty("CurrencyRefNavigation")]
        public virtual ICollection<InventoryLines> InventoryLines { get; set; }
        [InverseProperty("CurrencyRefNavigation")]
        public virtual ICollection<OrderLines> OrderLines { get; set; }
        [InverseProperty("CurrencyRefNavigation")]
        public virtual ICollection<PriceLists> PriceLists { get; set; }
        [InverseProperty("UserCurrencyTypeNavigation")]
        public virtual ICollection<Users> Users { get; set; }
    }
}
