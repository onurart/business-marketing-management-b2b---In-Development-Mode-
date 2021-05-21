using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TredeWeb.DataLayer;
using TredeWeb.Interfaces;

namespace TredeWeb.Repository
{
    public class CampaignsRepositor : RepositoryBase<Campaigns>, ICampaignsRepositor
    {
        public CampaignsRepositor(TradeDbContext context)
       : base(context)
        {
        }

        public void CreateCampaign(Campaigns campaign)
        {
            CreateCampaign(campaign);
        }
        public void DeleteCampaign(Campaigns campaign)
        {
            DeleteCampaign(campaign);
        }
        public void UpdateCampaign(Campaigns campaign)
        {
            UpdateCampaign(campaign);
        }





        public async Task<IEnumerable<Campaigns>> GetAllCampaignAsync()
        {
            return await FindAll()
                .OrderBy(ow => ow.Id)
                .ToListAsync();
        }
        public async Task<Campaigns> GetCampaignByIdAsync(int id)
        {
           return await FindByCondition(ac => ac.Id.Equals(id))
               .FirstOrDefaultAsync();
        }
        public async Task<Campaigns> GetCampaignWithDetailsAsync(int id)
        {
            return await FindByCondition(st => st.Id.Equals(id))
                 .Include(ac => ac.CampaignLines)
                 .Include(ac => ac.CampaignToAccounts)
                 .Include(ac => ac.CampaignToItems)            
                                       .FirstOrDefaultAsync();
        }
        public async Task Update(int id)
        {
            await context.SaveChangesAsync();
        }

    }
}
