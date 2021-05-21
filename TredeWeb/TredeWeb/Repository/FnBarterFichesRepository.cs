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
    public class FnBarterFichesRepository : RepositoryBase<FnBarterFiches>, IFnBarterFichesRepository                                                                             
    {
        public FnBarterFichesRepository(TradeDbContext context)
        : base(context)
        {
        }
        public void CreateFnBarterFiches(FnBarterFiches FnBarterFiches)
        {
            CreateFnBarterFiches(FnBarterFiches);
        }
        public void DeleteFnBarterFiches(FnBarterFiches FnBarterFiches)
        {
            DeleteFnBarterFiches(FnBarterFiches);
        }
        public void UpdateFnBarterFiches(FnBarterFiches FnBarterFiches)
        {
            UpdateFnBarterFiches(FnBarterFiches);
        }




        public async Task<IEnumerable<FnBarterFiches>> GetAllFnBarterFichesAsync()
        {
            return await FindAll()
                .OrderBy(ow => ow.Id)
                .ToListAsync();

        }
        public  async  Task<FnBarterFiches> GetFnBarterFichesByIdAsync(int id)
        {
            return await FindByCondition(ac => ac.Id.Equals(id))
               .FirstOrDefaultAsync();
        }
        public async Task<FnBarterFiches> GetFnBarterFichesWithDetailsAsync(int id)
        {
            return await FindByCondition(ac => ac.Id.Equals(id))
                                .Include(ac => ac.FnFiches)
                                                   .FirstOrDefaultAsync();
        }
        public async Task Update(int id)
        {
            await context.SaveChangesAsync();
        }

      
    }
}
