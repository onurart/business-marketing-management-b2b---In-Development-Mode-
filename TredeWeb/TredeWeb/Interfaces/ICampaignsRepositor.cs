using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TredeWeb.DataLayer;

namespace TredeWeb.Interfaces
{
    public interface ICampaignsRepositor : IRepositoryBase<Campaigns>
    {
        Task<IEnumerable<Campaigns>> GetAllCampaignAsync();
        Task<Campaigns> GetCampaignByIdAsync(int id);
        Task<Campaigns> GetCampaignWithDetailsAsync(int id);
        void CreateCampaign(Campaigns campaign);
        void UpdateCampaign(Campaigns campaign);
        void DeleteCampaign(Campaigns campaign);
        Task Update(int id);
    }
}
