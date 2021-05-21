using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TredeWeb.DataLayer;

namespace TredeWeb.Models
{
    public class BankAccount
    {
        //    public BankAccount()
        //    {
        //        FnBankLines = new HashSet<FnBankLines>();
        //    }

        [Key]
        public int Id { get; set; }
        public int? BankBranch { get; set; }
        [StringLength(100)]
        public string Code { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public int? OwnerRef { get; set; }
        [StringLength(100)]
        public string IbanNo { get; set; }
        public bool? IsActive { get; set; }

        [ForeignKey(nameof(BankBranch))]
        [InverseProperty(nameof(BankBranches.BankAccounts))]
        public virtual BankBranches BankBranchNavigation { get; set; }
        [ForeignKey(nameof(OwnerRef))]
        [InverseProperty(nameof(Users.BankAccounts))]
        public virtual Users OwnerRefNavigation { get; set; }
        //[InverseProperty("BankAccountRefNavigation")]
        //public virtual ICollection<FnBankLine> FnBankLines { get; set; }
    }
}
