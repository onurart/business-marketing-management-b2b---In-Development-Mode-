using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TredeWeb.DataLayer;

namespace TredeWeb.Models
{
    public class FnBarterFich
    {


        [Key]
        public int Id { get; set; }
        public int? FinanceRef { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ApproveDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FicheDate { get; set; }
        public bool? IsApproved { get; set; }
        [StringLength(100)]
        public string Number { get; set; }
        public int? Owner { get; set; }
        public bool? IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }

        [ForeignKey(nameof(Id))]
        [InverseProperty("FnBarterFiches")]
        public virtual FnFiches IdNavigation { get; set; }
        [ForeignKey(nameof(Owner))]
        [InverseProperty(nameof(Users.FnBarterFiches))]
        public virtual Users OwnerNavigation { get; set; }
        [InverseProperty("FicheRefNavigation")]
        public virtual ICollection<FnBarterLines> FnBarterLines { get; set; }
        [InverseProperty("BarterFicheRefNavigation")]
        public virtual ICollection<FnFiches> FnFiches { get; set; }

    }
}
