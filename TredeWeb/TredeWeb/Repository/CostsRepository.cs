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
    public class CostsRepository : RepositoryBase<Costs>, ICostsRepository
    {
        public CostsRepository(TradeDbContext context)
        : base(context)
        {
        }

        public void CreateCosts(Costs costs)
        {
            CreateCosts(costs);
        }
        public void DeleteCosts(Costs costs)
        {
            DeleteCosts(costs);
        }
        public void UpdateCosts(Costs costs)
        {
            UpdateCosts(costs);
        }

        public async Task<IEnumerable<Costs>> GetAllCostsAsync()
        {
            return await FindAll()
               .OrderBy(ow => ow.Id)
               .ToListAsync();

        }
        public async Task<Costs> GetCostsByIdAsync(int id)
        {

            return await FindByCondition(ac => ac.Id.Equals(id))
              .FirstOrDefaultAsync();
        }
        public async Task<Costs> GetCostsWithDetailsAsync(int id)
        {
            return await FindByCondition(ac => ac.Id.Equals(id))
                                .Include(ac => ac.FnBankLines)
                                .Include(ac => ac.FnCashLines)
                                .Include(ac => ac.FnCreditCardLines)
                                .Include(ac => ac.FnCsLines)
                                .Include(ac => ac.FnFicheLines)
                            .FirstOrDefaultAsync();
        }

        public async Task Update(int id)
        {
            await context.SaveChangesAsync();
        }

    }
}
