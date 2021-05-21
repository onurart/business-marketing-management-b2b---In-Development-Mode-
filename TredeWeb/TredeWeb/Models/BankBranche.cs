using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TredeWeb.Models
{
    public class BankBranche
    {
        public BankBranche()
        {
            //BankAccounts = new HashSet<BankAccounts>();
            //FnBankLines = new HashSet<FnBankLines>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Code { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public int? AddressRef { get; set; }
        [StringLength(100)]
        public string AuthorizePerson { get; set; }
        public int? BankCardRef { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [StringLength(100)]
        public string MailAddress { get; set; }
        [StringLength(100)]
        public string MobileNumber { get; set; }
        public int? OwnerRef { get; set; }
        [StringLength(100)]
        public string PhoneNumber { get; set; }
        [StringLength(100)]
        public string Specode { get; set; }
        public bool? IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        //[ForeignKey(nameof(AddressRef))]
        //[InverseProperty(nameof(Addresses.BankBranches))]
        //public virtual Addresses AddressRefNavigation { get; set; }
        //[ForeignKey(nameof(BankCardRef))]
        //[InverseProperty(nameof(BankCards.BankBranches))]
        //public virtual BankCards BankCardRefNavigation { get; set; }
        //[ForeignKey(nameof(OwnerRef))]
        //[InverseProperty(nameof(Users.BankBranches))]
        //public virtual Users OwnerRefNavigation { get; set; }
        //[InverseProperty("BankBranchNavigation")]
        //public virtual ICollection<BankAccounts> BankAccounts { get; set; }
        //[InverseProperty("BranchRefNavigation")]
        //public virtual ICollection<FnBankLines> FnBankLines { get; set; }
    }
}
