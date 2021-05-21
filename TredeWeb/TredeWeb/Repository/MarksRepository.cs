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
    public class MarksRepository : RepositoryBase<Marks>, IMarksRepository
    {
        public MarksRepository(TradeDbContext context)
        : base(context)
        {
        }

        public void CreateMarks(Marks mark)
        {
            Create(mark);
        }

        public void DeleteMarks(Marks mark)
        {
            Delete(mark);
        }

        public void UpdateMarks(Marks mark)
        {
            Update(mark);
        }
        public async Task<IEnumerable<Marks>> GetAllMarksAsync()
        {
            return await FindAll()
             .OrderBy(ow => ow.Name)
             .ToListAsync();
        }

        public async Task<Marks> GetMarksByIdAsync(int id)
        {

            return await FindByCondition(m => m.Id.Equals(id))
               .FirstOrDefaultAsync();
        }

        public async Task<Marks> GetMarksWithDetailsAsync(int id)
        {
            return await FindByCondition(cast => cast.Id.Equals(id))
           .Include(ac => ac.Items)
           .Include(ac => ac.Pictures)
                            .FirstOrDefaultAsync();
        }

        public Task Update(int id)
        {
            throw new NotImplementedException();
        }
        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

    }
}
