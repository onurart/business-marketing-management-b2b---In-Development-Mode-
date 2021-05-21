using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TredeWeb.DataLayer;

namespace TredeWeb.Interfaces
{
    public interface ICampaignLinesRepository : IRepositoryBase<CampaignLines>
    {
        Task<IEnumerable<CampaignLines>> GetAllCampaignLinesAsync();
        Task<CampaignLines> GetCampaignLinesByIdAsync(int id);
        Task<CampaignLines> GetCampaignLinesWithDetailsAsync(int id);
        void CreateCampaignLines(CampaignLines campaignLines);
        void UpdateCampaignLines(CampaignLines campaignLines);
        void DeleteCampaignLines(CampaignLines campaignLines);
        Task Update(int id);
    }
}
