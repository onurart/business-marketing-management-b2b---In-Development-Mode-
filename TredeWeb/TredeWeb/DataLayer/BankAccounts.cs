using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TredeWeb.DataLayer
{
    public partial class BankAccounts
    {
        public BankAccounts()
        {
            FnBankLines = new HashSet<FnBankLines>();
        }

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
        [InverseProperty("BankAccountRefNavigation")]
        public virtual ICollection<FnBankLines> FnBankLines { get; set; }
    }
}
