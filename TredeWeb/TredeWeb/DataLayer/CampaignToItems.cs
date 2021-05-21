using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TredeWeb.DataLayer
{
    public partial class CampaignToItems
    {
        [Key]
        public int CampaignId { get; set; }
        [Key]
        public int ItemId { get; set; }

        [ForeignKey(nameof(CampaignId))]
        [InverseProperty(nameof(DataLayer.Campaigns.CampaignToItems))]
        public virtual Campaigns Campaign { get; set; }
        [ForeignKey(nameof(ItemId))]
        [InverseProperty(nameof(Items.CampaignToItems))]
        public virtual Items Item { get; set; }
    }
}
