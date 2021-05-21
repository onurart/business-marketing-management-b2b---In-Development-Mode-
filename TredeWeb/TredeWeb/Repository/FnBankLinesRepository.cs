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
    public class FnBankLinesRepository : RepositoryBase<FnBankLines>, IFnBankLinesRepository
    {
        public FnBankLinesRepository(TradeDbContext context)
       : base(context)
        {
        }
        public void CreateFnBankLines(FnBankLines fnBankLines)
        {
            CreateFnBankLines(fnBankLines);
        }
        public void DeleteFnBankLines(FnBankLines fnBankLines)
        {
            DeleteFnBankLines(fnBankLines);
        }
        public void UpdateFnBankLines(FnBankLines fnBankLines)
        {
            UpdateFnBankLines(fnBankLines);
        }



        public async Task<IEnumerable<FnBankLines>> GetAllFnBankLinesAsync()
        {
                                return await FindAll()
                        .OrderBy(ow => ow.Id)
                        .ToListAsync();
        }
        public async Task<FnBankLines> GetFnBankLinesByIdAsync(int id)
        {
            return await FindByCondition(ac => ac.Id.Equals(id))
               .FirstOrDefaultAsync();
        }
        public async Task<FnBankLines> GetFnBankLinesWithDetailsAsync(int id)
        {
            return await FindByCondition(ac => ac.Id.Equals(id))
                               .Include(ac => ac.Costs)
                               .Include(ac => ac.FnFicheLines)
                             .FirstOrDefaultAsync();
        }
        public async Task Update(int id)
        {
            await context.SaveChangesAsync();
        }

     
    }
}
