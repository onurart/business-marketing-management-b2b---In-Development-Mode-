using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TredeWeb.DataLayer
{
    public partial class CampaignLines
    {
        [Key]
        public int Id { get; set; }
        public int? CampaignRef { get; set; }
        public int? ItemRef { get; set; }
        public double? Amount { get; set; }
        public int? AccountRef { get; set; }
        public bool? IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [ForeignKey(nameof(AccountRef))]
        [InverseProperty(nameof(Accounts.CampaignLines))]
        public virtual Accounts AccountRefNavigation { get; set; }
        [ForeignKey(nameof(CampaignRef))]
        [InverseProperty(nameof(Campaigns.CampaignLines))]
        public virtual Campaigns CampaignRefNavigation { get; set; }
        [ForeignKey(nameof(ItemRef))]
        [InverseProperty(nameof(Items.CampaignLines))]
        public virtual Items ItemRefNavigation { get; set; }
    }
}
