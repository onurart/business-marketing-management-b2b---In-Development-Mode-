using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TredeWeb.Models
{
    public class FnBankLines
    {


        [Key]
        public int Id { get; set; }
        public int? AccountRef { get; set; }
        [Column(TypeName = "money")]
        public decimal? Amount { get; set; }
        public int? BankAccountRef { get; set; }
        public int? BranchRef { get; set; }
        public int? BankCardRef { get; set; }
        [Column(TypeName = "money")]
        public decimal? Cost { get; set; }
        public int? Currency { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [StringLength(100)]
        public string DocumentNumber { get; set; }
        public int? FicheRef { get; set; }
        public bool? IsCostInclude { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LineDate { get; set; }
        public int? LineNr { get; set; }
        public int? Sign { get; set; }
        public int? Type { get; set; }
        public int? FinanceLineRef { get; set; }
        public int? CostRef { get; set; }
        public bool? IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

    }
}
