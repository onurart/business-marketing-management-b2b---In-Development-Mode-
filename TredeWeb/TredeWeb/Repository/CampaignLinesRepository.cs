using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TredeWeb.DataLayer;
using TredeWeb.Interfaces;

namespace TredeWeb.Repository
{
    public class CampaignLinesRepository : RepositoryBase<CampaignLines>, ICampaignLinesRepository
    {
        public CampaignLinesRepository(TradeDbContext context)
       : base(context)
        {
        }

        public void CreateCampaignLines(CampaignLines campaignLines)
        {
            CreateCampaignLines(campaignLines);
        }
        public void DeleteCampaignLines(CampaignLines campaignLines)
        {
            DeleteCampaignLines(campaignLines);
        }
        public void UpdateCampaignLines(CampaignLines campaignLines)
        {
            UpdateCampaignLines(campaignLines);
        }




        public async Task<CampaignLines> GetCampaignLinesWithDetailsAsync(int id)
        {
            return await FindByCondition(ac => ac.Id.Equals(id)).
                FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<CampaignLines>> GetAllCampaignLinesAsync()
        {
            return await FindAll()
                 .OrderBy(ow => ow.Id)
                 .ToListAsync();
        }
        public async Task<CampaignLines> GetCampaignLinesByIdAsync(int id)
        {
            return await FindByCondition(ac => ac.Id.Equals(id))
            .FirstOrDefaultAsync();
        }
        public async Task Update(int id)
        {
            await context.SaveChangesAsync();
        }
    }
}
