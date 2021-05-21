using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TredeWeb.DataLayer;

namespace TredeWeb.Models
{
    public class ItemToTag
    {
        [Key]
        public int ItemId { get; set; }
        [Key]
        public int TagId { get; set; }

        [ForeignKey(nameof(ItemId))]
        [InverseProperty(nameof(Items.ItemToTags))]
        public virtual Items Item { get; set; }
        [ForeignKey(nameof(TagId))]
        [InverseProperty(nameof(Tags.ItemToTags))]
        public virtual Tags Tag { get; set; }
    }
}
