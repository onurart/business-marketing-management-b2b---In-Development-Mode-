using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TredeWeb.DataLayer;

namespace TredeWeb.Models
{
    public class ItemToVariant
    {
        [Key]
        public int ItemId { get; set; }
        [Key]
        public int VariantId { get; set; }

        [ForeignKey(nameof(ItemId))]
        [InverseProperty(nameof(Items.ItemToVariants))]
        public virtual Items Item { get; set; }
        [ForeignKey(nameof(VariantId))]
        [InverseProperty(nameof(Variants.ItemToVariants))]
        public virtual Variants Variant { get; set; }

    }
}
