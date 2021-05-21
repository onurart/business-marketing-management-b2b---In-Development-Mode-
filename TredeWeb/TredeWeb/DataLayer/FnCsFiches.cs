using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TredeWeb.DataLayer
{
    public partial class FnCsFiches
    {
        public FnCsFiches()
        {
            FnCsLines = new HashSet<FnCsLines>();
        }

        [Key]
        public int Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ApproveDate { get; set; }
        public int? CsFicheType { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        public int? FinanceRef { get; set; }
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
        [InverseProperty(nameof(FnFiches.FnCsFiches))]
        public virtual FnFiches FinanceRefNavigation { get; set; }
        [ForeignKey(nameof(Owner))]
        [InverseProperty(nameof(Users.FnCsFiches))]
        public virtual Users OwnerNavigation { get; set; }
        [InverseProperty("FicheRefNavigation")]
        public virtual ICollection<FnCsLines> FnCsLines { get; set; }
    }
}
