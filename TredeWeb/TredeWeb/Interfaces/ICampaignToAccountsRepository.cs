using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TredeWeb.DataLayer;

namespace TredeWeb.Interfaces
{
    public interface ICampaignToAccountsRepository : IRepositoryBase<CampaignToAccounts>
    {
        Task<IEnumerable<CampaignToAccounts>> GetAllCampaignToAccountsAsync();
        Task<CampaignToAccounts> GetCampaignToAccountsByIdAsync(int id);
        Task<CampaignToAccounts> GetCampaignToAccountsWithDetailsAsync(int id);
        void CreateCampaignToAccounts(CampaignToAccounts campaignToAccounts);
        void UpdateCampaignToAccounts(CampaignToAccounts campaignToAccounts);
        void DeleteCampaignToAccounts(CampaignToAccounts campaignToAccounts);
        Task Update(int id);
    }
}
