using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TredeWeb.DataLayer;

namespace TredeWeb.Interfaces
{
    public interface ICategoriesRepository : IRepositoryBase<Categories>
    {
        Task<IEnumerable<Categories>> GetAllCategoriesAsync();
        Task<Categories> GetCategoriesByIdAsync(int id);
        Task<Categories> GetCategoriesWithDetailsAsync(int id);
        void CreateCategories(Categories categories);
        void UpdateCategories(Categories categories);
        void DeleteCategories(Categories categories);
        Task Update(int id);
    }
}
