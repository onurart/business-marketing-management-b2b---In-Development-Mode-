using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TredeWeb.DataLayer;

namespace TredeWeb.Models
{
    public class CampaignToItem
    {
        [Key]
        public int CampaignId { get; set; }
        [Key]
        public int ItemId { get; set; }

        [ForeignKey(nameof(ItemId))]
        [InverseProperty(nameof(Items.CampaignToItems))]
        public virtual Items Item { get; set; }
    }
}
