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
    public class FnCashFichesRepository : RepositoryBase<FnCashFiches>, IFnCashFichesRepository
    {
        public FnCashFichesRepository(TradeDbContext context)
       : base(context)
        {
        }
        public void CreateFnCashFiches(FnCashFiches fnCashFiches)
        {
            CreateFnCashFiches(fnCashFiches);
        }
        public void DeleteFnCashFiches(FnCashFiches fnCashFiches)
        {
            DeleteFnCashFiches(fnCashFiches);
        }
        public void UpdateFnCashFiches(FnCashFiches fnCashFiches)
        {
            UpdateFnCashFiches(fnCashFiches);
        }


        public async Task<IEnumerable<FnCashFiches>> GetAllFnCashFichesAsync()
        {

            return await FindAll()
                .OrderBy(ow => ow.Id)
                .ToListAsync();
        }
        public async Task<FnCashFiches> GetFnCashFichesByIdAsync(int id)
        {
            return await FindByCondition(ac => ac.Id.Equals(id))
          .FirstOrDefaultAsync();
        }     
        public async Task<FnCashFiches> GetFnCashFichestWithDetailsAsync(int id)
        {
            return await FindByCondition(ac => ac.Id.Equals(id))
                  .Include(ac => ac.FnCashLines)
                  .Include(ac => ac.FnFiches)
                     .FirstOrDefaultAsync();
        }
        public async Task Update(int id)
        {
            await context.SaveChangesAsync();
        }

    
    }
}
