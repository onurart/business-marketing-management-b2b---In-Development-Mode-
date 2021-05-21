using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TredeWeb.DataLayer
{
    public partial class ItemToCategories
    {
        [Key]
        public int CategoryId { get; set; }
        [Key]
        public int ItemId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty(nameof(Categories.ItemToCategories))]
        public virtual Categories Category { get; set; }
        [ForeignKey(nameof(ItemId))]
        [InverseProperty(nameof(Items.ItemToCategories))]
        public virtual Items Item { get; set; }
    }
}
