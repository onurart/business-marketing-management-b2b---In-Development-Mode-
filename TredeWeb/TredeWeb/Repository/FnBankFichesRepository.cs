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
    public class FnBankFichesRepository : RepositoryBase<FnBankFiches>, IFnBankFichesRepository
    {
        public FnBankFichesRepository(TradeDbContext context)
        : base(context)
        {
        }

        public void CreateFnBankFiches(FnBankFiches fnBankFiches)
        {
            CreateFnBankFiches(fnBankFiches);
        }
        public void DeleteFnBankFiches(FnBankFiches fnBankFiches)
        {
            DeleteFnBankFiches(fnBankFiches);
        }
        public void UpdateFnBankFiches(FnBankFiches fnBankFiches)
        {
            UpdateFnBankFiches(fnBankFiches);
        }


        public async Task<IEnumerable<FnBankFiches>> GetAllFnBankFichesAsync()
        {
            return await FindAll()
              .OrderBy(ow => ow.Id)
              .ToListAsync();
        }
        public async Task<FnBankFiches> GetFnBankFichesByIdAsync(int id)
        {
            return await FindByCondition(ac => ac.Id.Equals(id))
                .FirstOrDefaultAsync();
        }
        public async Task<FnBankFiches> GetFnBankFichesWithDetailsAsync(int id)
        {
            return await FindByCondition(ac => ac.Id.Equals(id))
                                 .Include(ac => ac.FnBankLines)
                                 .Include(ac => ac.FnFiches)
                                                         .FirstOrDefaultAsync();
        }
        public async Task Update(int id)
        {
            await context.SaveChangesAsync();
        }

    }
}
