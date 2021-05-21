using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TredeWeb.DataLayer
{
    public partial class FnCreditCardFiches
    {
        public FnCreditCardFiches()
        {
            FnCreditCardLines = new HashSet<FnCreditCardLines>();
            FnFiches = new HashSet<FnFiches>();
        }

        [Key]
        public int Id { get; set; }
        public int FinanceRef { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ApproveDate { get; set; }
        public bool IsApproved { get; set; }
        [Required]
        [StringLength(100)]
        public string Number { get; set; }
        public int Owner { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FicheDate { get; set; }
        public int Type { get; set; }
        public int? Order { get; set; }
        public bool IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }

        [ForeignKey(nameof(FinanceRef))]
        [InverseProperty("FnCreditCardFiches")]
        public virtual FnFiches FinanceRefNavigation { get; set; }
        [ForeignKey(nameof(Owner))]
        [InverseProperty(nameof(Users.FnCreditCardFiches))]
        public virtual Users OwnerNavigation { get; set; }
        [InverseProperty("FicheRefNavigation")]
        public virtual ICollection<FnCreditCardLines> FnCreditCardLines { get; set; }
        [InverseProperty("CreditCardFicheRefNavigation")]
        public virtual ICollection<FnFiches> FnFiches { get; set; }
    }
}
