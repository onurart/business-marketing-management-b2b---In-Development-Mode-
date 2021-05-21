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
    public class FnCashLinesrepository : RepositoryBase<FnCashLines>, IFnCashLinesrepository
    {
        public FnCashLinesrepository(TradeDbContext context)
       : base(context)
        {
        }
        public void CreateFnCashLines(FnCashLines fnCashLines)
        {
            CreateFnCashLines(fnCashLines);
        }
        public void DeleteFnCashLines(FnCashLines fnCashLines)
        {
            DeleteFnCashLines(fnCashLines);
        }
        public void UpdateFnCashLines(FnCashLines fnCashLines)
        {
            UpdateFnCashLines(fnCashLines);
        }



        public async Task<IEnumerable<FnCashLines>> GetAllFnCashLinesAsync()
        {
            return await FindAll()
               .OrderBy(ow => ow.Id)
               .ToListAsync();
        }
        public async Task<FnCashLines> GetFnCashLinesByIdAsync(int id)
        {
            return await FindByCondition(ac => ac.Id.Equals(id))
         .FirstOrDefaultAsync();
        }
        public async Task<FnCashLines> GetFnCashLinesWithDetailsAsync(int id)
        {
            return await FindByCondition(ac => ac.Id.Equals(id))
                 .Include(ac => ac.FnFicheLines)
                .FirstOrDefaultAsync();
        }
        public async Task Update(int id)
        {
            await context.SaveChangesAsync();
        }

  
    }
}
