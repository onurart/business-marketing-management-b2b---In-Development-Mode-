using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TredeWeb.Models
{
    public class CashCard
    {
        //public CashCard()
        //{
        //    FnCashFiches = new HashSet<FnCashFich>();
        //    FnFicheLines = new HashSet<FnFicheLines>();

        //}

        [Key]
        public int Id { get; set; }
        public int? ParentCard { get; set; }
        [StringLength(100)]
        public string Code { get; set; }
        [StringLength(100)]
        public string CardName { get; set; }
        public int? AccountRef { get; set; }
        public int? OwnerRef { get; set; }
        public bool? IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

    }
}
