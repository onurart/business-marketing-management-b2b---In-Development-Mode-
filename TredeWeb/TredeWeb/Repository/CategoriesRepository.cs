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
    public class CategoriesRepository : RepositoryBase<Categories>, ICategoriesRepository
    {
        public CategoriesRepository(TradeDbContext context)
        : base(context)
        {
        }

        public void CreateCategories(Categories categories)
        {
            Create(categories);
        }

        public void DeleteCategories(Categories categories)
        {
            Delete(categories);
        }

        public void UpdateCategories(Categories categories)
        {
            Update(categories);
        }


        public async Task<IEnumerable<Categories>> GetAllCategoriesAsync()
        {
            return await FindAll()
             .OrderBy(ow => ow.Name)
             .ToListAsync();
        }

        public async Task<Categories> GetCategoriesByIdAsync(int id)
        {
            return await FindByCondition(Categ => Categ.Id.Equals(id))
              .FirstOrDefaultAsync();
        }

        public async Task<Categories> GetCategoriesWithDetailsAsync(int id)
        {
            return await FindByCondition(cast => cast.Id.Equals(id))
      .Include(ac => ac.InverseParentCategoryNavigation)
      .Include(ac => ac.ItemToCategories)
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
