using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TredeWeb.DataLayer;

namespace TredeWeb.Models
{
    public class BankCard
    {
        public BankCard()
        {
            BankBranches = new HashSet<BankBranches>();
            //FnBankLines = new HashSet<FnBankLine>();
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
        //[InverseProperty("BankCardRefNavigation")]
        //public virtual ICollection<FnBankLine> FnBankLines { get; set; }
    }
}
