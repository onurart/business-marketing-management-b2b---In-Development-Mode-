using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TredeWeb.DataLayer;

namespace TredeWeb.Interfaces
{
    public interface ICostsRepository : IRepositoryBase<Costs>
    {
        Task<IEnumerable<Costs>> GetAllCostsAsync();
        Task<Costs> GetCostsByIdAsync(int id);
        Task<Costs> GetCostsWithDetailsAsync(int id);
        void CreateCosts(Costs costs);
        void UpdateCosts(Costs costs);
        void DeleteCosts(Costs costs);
        Task Update(int id);
    }
}
