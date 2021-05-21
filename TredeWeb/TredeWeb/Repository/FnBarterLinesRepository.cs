using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TredeWeb.DataLayer;
using TredeWeb.Interfaces;
namespace TredeWeb.Repository
{
    public class FnBarterLinesRepository : RepositoryBase<FnBarterLines>, IFnBarterLinesRepository
    {
        public FnBarterLinesRepository(TradeDbContext context)
       : base(context)
        {
        }
        public void CreateFnBarterLines(FnBarterLines fnBarterLines)
        {
            CreateFnBarterLines(fnBarterLines);
        }
        public void DeleteFnBarterLines(FnBarterLines fnBarterLines)
        {
            DeleteFnBarterLines(fnBarterLines);
        }
        public void UpdateFnBarterLines(FnBarterLines fnBarterLines)
        {
            UpdateFnBarterLines(fnBarterLines);
        }


        public async Task<IEnumerable<FnBarterLines>> GetAllFnBarterLinesAsync()
        {
            return await FindAll()
                .OrderBy(ow => ow.Id)
                .ToListAsync();
        }
        public async Task<FnBarterLines> GetFnBarteLinesWithDetailsAsync(int id)
        {
            return await FindByCondition(ac => ac.Id.Equals(id))
                  .Include(ac => ac.FnFicheLines)
             .FirstOrDefaultAsync();
        }
        public async Task<FnBarterLines> GetFnBarterLinesByIdAsync(int id)
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
