using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TredeWeb.DataLayer;

namespace TredeWeb.Models
{
    public class User
    {
        public User()
        {
            Accounts = new HashSet<Account>();
            Addresses = new HashSet<Address>();
            BankAccounts = new HashSet<DataLayer.BankAccounts>();
            BankBranches = new HashSet<BankBranches>();
            BankCards = new HashSet<DataLayer.BankCards>();
            Barcodes = new HashSet<DataLayer.Barcodes>();
            Campaigns = new HashSet<DataLayer.Campaigns>();
            CashCards = new HashSet<DataLayer.CashCards>();
            //Categories = new HashSet<Category>();
            Costs = new HashSet<DataLayer.Costs>();
            CouponCodes = new HashSet<DataLayer.CouponCodes>();
            FnBankFiches = new HashSet<FnBankFiches>();
            FnBarterFiches = new HashSet<FnBarterFiches>();
            FnCashFiches = new HashSet<FnCashFich>();
            FnCreditCardFiches = new HashSet<FnCreditCardFiches>();
            FnCsFiches = new HashSet<FnCsFiches>();
            FnFiches = new HashSet<FnFiches>();
            Inventories = new HashSet<Inventories>();
            InventoryLines = new HashSet<InventoryLines>();
            InverseOwnerRefNavigation = new HashSet<Users>();
            Marks = new HashSet<Marks>();
            Orders = new HashSet<Orders>();
            PriceLists = new HashSet<PriceLists>();
            UserToRoles = new HashSet<UserToRoles>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        public string UserName { get; set; }
        public bool? ChangePasswordOnFirstLogon { get; set; }
        [StringLength(200)]
        public string StoredPassword { get; set; }
        public int? UserCurrencyType { get; set; }
        public int? Department { get; set; }
        public int? Position { get; set; }
        public int? Location { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? BirthDay { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string MiddleName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(200)]
        public string Title { get; set; }
        public int? AccountRef { get; set; }
        public byte[] UserImage { get; set; }
        public int? OwnerRef { get; set; }
        public int? AddressRef { get; set; }
        [StringLength(100)]
        public string PhoneNumber { get; set; }
        [StringLength(12)]
        public string TaxNr { get; set; }
        [StringLength(30)]
        public string TaxOffice { get; set; }
        [Column("TCKNo")]
        [StringLength(12)]
        public string Tckno { get; set; }
        [StringLength(100)]
        public string MobileNumber { get; set; }
        public bool? IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [ForeignKey(nameof(AccountRef))]
        [InverseProperty("Users")]
        public virtual Account AccountRefNavigation { get; set; }
        [ForeignKey(nameof(AddressRef))]
        [InverseProperty("Users")]
        public virtual Address AddressRefNavigation { get; set; }
        [ForeignKey(nameof(Department))]
        [InverseProperty(nameof(Departments.Users))]
        public virtual Departments DepartmentNavigation { get; set; }
        [ForeignKey(nameof(OwnerRef))]
        [InverseProperty(nameof(Users.InverseOwnerRefNavigation))]
        public virtual Users OwnerRefNavigation { get; set; }
        [ForeignKey(nameof(Position))]
        [InverseProperty(nameof(Positions.Users))]
        public virtual Positions PositionNavigation { get; set; }
        [ForeignKey(nameof(UserCurrencyType))]
        [InverseProperty(nameof(DataLayer.Currencies.Users))]
        public virtual DataLayer.Currencies UserCurrencyTypeNavigation { get; set; }
        [InverseProperty("UserRefNavigation")]
        public virtual ICollection<Account> Accounts { get; set; }
        [InverseProperty("OwnerRefNavigation")]
        public virtual ICollection<Address> Addresses { get; set; }
        [InverseProperty("OwnerRefNavigation")]
        public virtual ICollection<DataLayer.BankAccounts> BankAccounts { get; set; }
        [InverseProperty("OwnerRefNavigation")]
        public virtual ICollection<BankBranches> BankBranches { get; set; }
        [InverseProperty("OwnerRefNavigation")]
        public virtual ICollection<DataLayer.BankCards> BankCards { get; set; }
        [InverseProperty("OwnerRefNavigation")]
        public virtual ICollection<DataLayer.Barcodes> Barcodes { get; set; }
        [InverseProperty("OwnerRefNavigation")]
        public virtual ICollection<DataLayer.Campaigns> Campaigns { get; set; }
        [InverseProperty("OwnerRefNavigation")]
        public virtual ICollection<DataLayer.CashCards> CashCards { get; set; }
        //[InverseProperty("OwnerRefNavigation")]
        //public virtual ICollection<Category> Categories { get; set; }
        [InverseProperty("OwnerRefNavigation")]
        public virtual ICollection<DataLayer.Costs> Costs { get; set; }
        [InverseProperty("OwnerRefNavigation")]
        public virtual ICollection<DataLayer.CouponCodes> CouponCodes { get; set; }
        [InverseProperty("OwnerNavigation")]
        public virtual ICollection<FnBankFiches> FnBankFiches { get; set; }
        [InverseProperty("OwnerNavigation")]
        public virtual ICollection<FnBarterFiches> FnBarterFiches { get; set; }
        [InverseProperty("OwnerNavigation")]
        public virtual ICollection<FnCashFich> FnCashFiches { get; set; }
        [InverseProperty("OwnerNavigation")]
        public virtual ICollection<FnCreditCardFiches> FnCreditCardFiches { get; set; }
        [InverseProperty("OwnerNavigation")]
        public virtual ICollection<FnCsFiches> FnCsFiches { get; set; }
        [InverseProperty("OwnerNavigation")]
        public virtual ICollection<FnFiches> FnFiches { get; set; }
        [InverseProperty("OwnerRefNavigation")]
        public virtual ICollection<Inventories> Inventories { get; set; }
        [InverseProperty("OwnerRefNavigation")]
        public virtual ICollection<InventoryLines> InventoryLines { get; set; }
        [InverseProperty(nameof(Users.OwnerRefNavigation))]
        public virtual ICollection<Users> InverseOwnerRefNavigation { get; set; }
        [InverseProperty("OwnerNavigation")]
        public virtual ICollection<Marks> Marks { get; set; }
        [InverseProperty("OwnerRefNavigation")]
        public virtual ICollection<Orders> Orders { get; set; }
        [InverseProperty("OwnerRefNavigation")]
        public virtual ICollection<PriceLists> PriceLists { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<UserToRoles> UserToRoles { get; set; }
    }
}
