using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TredeWeb.DataLayer;

namespace TredeWeb.Models
{
    public class FnBankFich
    {
        public FnBankFich()
        {
            //FnBankLines = new HashSet<FnBankLine>();
            FnFiches = new HashSet<FnFiches>();
        }

        [Key]
        public int Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ApproveDate { get; set; }
        public int? FinanceRef { get; set; }
        public bool? IsAccounting { get; set; }
        public bool? IsApproved { get; set; }
        [StringLength(100)]
        public string Number { get; set; }
        public int? Owner { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FicheDate { get; set; }
        public bool? IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [ForeignKey(nameof(FinanceRef))]
        [InverseProperty("FnBankFiches")]
        public virtual FnFiches FinanceRefNavigation { get; set; }
        [ForeignKey(nameof(Owner))]
        [InverseProperty(nameof(Users.FnBankFiches))]
        public virtual Users OwnerNavigation { get; set; }
        //[InverseProperty("FicheRefNavigation")]
        //public virtual ICollection<FnBankLine> FnBankLines { get; set; }
        [InverseProperty("BankFicheRefNavigation")]
        public virtual ICollection<FnFiches> FnFiches { get; set; }
    }
}
