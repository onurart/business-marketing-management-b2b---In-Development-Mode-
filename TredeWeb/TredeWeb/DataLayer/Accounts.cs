using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TredeWeb.DataLayer
{
    public partial class Accounts
    {
        public Accounts()
        {
            CampaignLines = new HashSet<CampaignLines>();
            CampaignToAccounts = new HashSet<CampaignToAccounts>();
            CashCards = new HashSet<CashCards>();
            Costs = new HashSet<Costs>();
            FnBankLines = new HashSet<FnBankLines>();
            FnBarterLines = new HashSet<FnBarterLines>();
            FnCashLines = new HashSet<FnCashLines>();
            FnCreditCardLines = new HashSet<FnCreditCardLines>();
            FnCsLines = new HashSet<FnCsLines>();
            FnFicheLines = new HashSet<FnFicheLines>();
            InventoryLines = new HashSet<InventoryLines>();
            InverseParentAccountNavigation = new HashSet<Accounts>();
            Orders = new HashSet<Orders>();
            Users = new HashSet<Users>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        public string Title { get; set; }
        public int? AddressRef { get; set; }
        [StringLength(25)]
        public string AppleId { get; set; }
        public int? AverageMaturityDate { get; set; }
        public int? UserRef { get; set; }
        [StringLength(24)]
        public string Code { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [StringLength(50)]
        public string ExtSendEmail { get; set; }
        [StringLength(24)]
        public string ExtSendFaxNr { get; set; }
        [StringLength(100)]
        public string FacebookUrl { get; set; }
        public bool? FinBrws { get; set; }
        public bool? ImpBrws { get; set; }
        public bool? IsActive { get; set; }
        [StringLength(50)]
        public string MailAddress { get; set; }
        [StringLength(20)]
        public string MobileNumber { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public int? OwnerRef { get; set; }
        public int? ParentAccount { get; set; }
        [StringLength(20)]
        public string PhoneNumber { get; set; }
        public bool? PurchaseBrws { get; set; }
        public bool? SaleBrws { get; set; }
        [Column("SkypeID")]
        [StringLength(24)]
        public string SkypeId { get; set; }
        [StringLength(24)]
        public string Specode { get; set; }
        [StringLength(12)]
        public string TaxNr { get; set; }
        [StringLength(30)]
        public string TaxOffice { get; set; }
        [Column("TCKNo")]
        [StringLength(12)]
        public string Tckno { get; set; }
        [StringLength(50)]
        public string TwitterUrl { get; set; }
        [StringLength(50)]
        public string WebSite { get; set; }

        [ForeignKey(nameof(AddressRef))]
        [InverseProperty(nameof(Addresses.Accounts))]
        public virtual Addresses AddressRefNavigation { get; set; }
        [ForeignKey(nameof(ParentAccount))]
        [InverseProperty(nameof(Accounts.InverseParentAccountNavigation))]
        public virtual Accounts ParentAccountNavigation { get; set; }
        [ForeignKey(nameof(UserRef))]
        [InverseProperty("Accounts")]
        public virtual Users UserRefNavigation { get; set; }
        [InverseProperty("AccountRefNavigation")]
        public virtual ICollection<CampaignLines> CampaignLines { get; set; }
        [InverseProperty("Account")]
        public virtual ICollection<CampaignToAccounts> CampaignToAccounts { get; set; }
        [InverseProperty("AccountRefNavigation")]
        public virtual ICollection<CashCards> CashCards { get; set; }
        [InverseProperty("AccountRefNavigation")]
        public virtual ICollection<Costs> Costs { get; set; }
        [InverseProperty("AccountRefNavigation")]
        public virtual ICollection<FnBankLines> FnBankLines { get; set; }
        [InverseProperty("AccountRefNavigation")]
        public virtual ICollection<FnBarterLines> FnBarterLines { get; set; }
        [InverseProperty("AccountRefNavigation")]
        public virtual ICollection<FnCashLines> FnCashLines { get; set; }
        [InverseProperty("AccountRefNavigation")]
        public virtual ICollection<FnCreditCardLines> FnCreditCardLines { get; set; }
        [InverseProperty("AccountRefNavigation")]
        public virtual ICollection<FnCsLines> FnCsLines { get; set; }
        [InverseProperty("AccountRefNavigation")]
        public virtual ICollection<FnFicheLines> FnFicheLines { get; set; }
        [InverseProperty("AccountRefNavigation")]
        public virtual ICollection<InventoryLines> InventoryLines { get; set; }
        [InverseProperty(nameof(Accounts.ParentAccountNavigation))]
        public virtual ICollection<Accounts> InverseParentAccountNavigation { get; set; }
        [InverseProperty("AccountRefNavigation")]
        public virtual ICollection<Orders> Orders { get; set; }
        [InverseProperty("AccountRefNavigation")]
        public virtual ICollection<Users> Users { get; set; }
    }
}
