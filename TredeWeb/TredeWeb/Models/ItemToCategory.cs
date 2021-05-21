using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TredeWeb.DataLayer;

namespace TredeWeb.Models
{
    public class ItemToCategory
    {
        [Key]
        public int CategoryId { get; set; }
        [Key]
        public int ItemId { get; set; }

        //[ForeignKey(nameof(CategoryId))]
        //[InverseProperty(nameof(Models.Category.ItemToCategories))]
        //public virtual Category Category { get; set; }
        [ForeignKey(nameof(ItemId))]
        [InverseProperty(nameof(Items.ItemToCategories))]
        public virtual Items Item { get; set; }
    }
}
