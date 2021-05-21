using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TredeWeb.DataLayer;

namespace TredeWeb.Models
{
    public class Campaign
    {

        [Key]
        public int Id { get; set; }
        public int? PictureRef { get; set; }
        [StringLength(100)]
        public string GetCampainAdvantage { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        public int? OwnerRef { get; set; }
        public int? Type { get; set; }
        public int? Discount { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsAccountCampaign { get; set; }
        public bool? IsLimitedCampaign { get; set; }
        public double? CampaignLimit { get; set; }
        public double? CampaignTotal { get; set; }
        public int? CampaignAmount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? BeginDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EndDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }

        [ForeignKey(nameof(OwnerRef))]
        [InverseProperty(nameof(Users.Campaigns))]
        public virtual Users OwnerRefNavigation { get; set; }
        //[ForeignKey(nameof(PictureRef))]
        //[InverseProperty(nameof(Pictures.Campaigns))]
        //public virtual Pictures PictureRefNavigation { get; set; }
        //[InverseProperty("CampaignRefNavigation")]
        //public virtual ICollection<CampaignLines> CampaignLines { get; set; }
        //[InverseProperty("Campaign")]
        //public virtual ICollection<CampaignToAccounts> CampaignToAccounts { get; set; }
        //[InverseProperty("Campaign")]
        //public virtual ICollection<CampaignToItems> CampaignToItems { get; set; }
    }
}
