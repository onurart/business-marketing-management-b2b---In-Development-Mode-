using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TredeWeb.DataLayer;
using TredeWeb.Interfaces;

namespace TredeWeb.Repository
{
    public class CampaignToAccountsRepository : RepositoryBase<CampaignToAccounts>, ICampaignToAccountsRepository
    {
        public CampaignToAccountsRepository(TradeDbContext context)
       : base(context)
        {
        }

        public void CreateCampaignToAccounts(CampaignToAccounts campaignToAccounts)
        {
            CreateCampaignToAccounts(campaignToAccounts);
        }
        public void DeleteCampaignToAccounts(CampaignToAccounts campaignToAccounts)
        {
            DeleteCampaignToAccounts(campaignToAccounts);
        }
        public void UpdateCampaignToAccounts(CampaignToAccounts campaignToAccounts)
        {
            UpdateCampaignToAccounts(campaignToAccounts);
        }



        public async Task<IEnumerable<CampaignToAccounts>> GetAllCampaignToAccountsAsync()
        {
            return await FindAll()
               .OrderBy(ow => ow.AccountId)
               .ToListAsync();
        }
        public async Task<CampaignToAccounts> GetCampaignToAccountsByIdAsync(int id)
        {
            return await FindByCondition(ac => ac.AccountId.Equals(id))
               .FirstOrDefaultAsync();
        }
        public async Task<CampaignToAccounts> GetCampaignToAccountsWithDetailsAsync(int id)
        {
            return await FindByCondition(ac => ac.AccountId.Equals(id))
            .FirstOrDefaultAsync();
        }
        public async Task Update(int id)
        {
            await context.SaveChangesAsync();
        }
    }
}
