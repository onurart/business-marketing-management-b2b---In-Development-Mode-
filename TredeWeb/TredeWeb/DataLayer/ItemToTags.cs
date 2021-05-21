using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TredeWeb.DataLayer
{
    public partial class ItemToTags
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
