using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TredeWeb.Models
{
    public class CampaignToAccount
    {
        [Key]
        public int AccountId { get; set; }
        [Key]
        public int CampaignId { get; set; }
    }
}
