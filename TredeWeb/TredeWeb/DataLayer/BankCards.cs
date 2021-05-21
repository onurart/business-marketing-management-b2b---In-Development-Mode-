using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TredeWeb.DataLayer
{
    public partial class BankCards
    {
        public BankCards()
        {
            BankBranches = new HashSet<BankBranches>();
            FnBankLines = new HashSet<FnBankLines>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Code { get; set; }
        public int? BınCode { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public int? OwnerRef { get; set; }
        [StringLength(100)]
        public string WebSite { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        public bool? IsActive { get; set; }

        [ForeignKey(nameof(OwnerRef))]
        [InverseProperty(nameof(Users.BankCards))]
        public virtual Users OwnerRefNavigation { get; set; }
        [InverseProperty("BankCardRefNavigation")]
        public virtual ICollection<BankBranches> BankBranches { get; set; }
        [InverseProperty("BankCardRefNavigation")]
        public virtual ICollection<FnBankLines> FnBankLines { get; set; }
    }
}
