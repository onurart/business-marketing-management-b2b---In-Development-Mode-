using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TredeWeb.DataLayer
{
    public partial class CampaignToAccounts
    {
        [Key]
        public int AccountId { get; set; }
        [Key]
        public int CampaignId { get; set; }

        [ForeignKey(nameof(AccountId))]
        [InverseProperty(nameof(DataLayer.Accounts.CampaignToAccounts))]
        public virtual Accounts Account { get; set; }
        [ForeignKey(nameof(CampaignId))]
        [InverseProperty(nameof(DataLayer.Campaigns.CampaignToAccounts))]
        public virtual Campaigns Campaign { get; set; }
    }
}
