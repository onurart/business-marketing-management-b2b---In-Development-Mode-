using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TredeWeb.DataLayer
{
    public partial class Variants
    {
        public Variants()
        {
            ItemToVariants = new HashSet<ItemToVariants>();
        }

        [Key]
        public int Id { get; set; }
        public int? ParentVariant { get; set; }
        [StringLength(50)]
        public string VariantName { get; set; }
        public int? VariantPrice { get; set; }
        [StringLength(50)]
        public string VariantValue { get; set; }
        public bool? IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [InverseProperty("Variant")]
        public virtual ICollection<ItemToVariants> ItemToVariants { get; set; }
    }
}
