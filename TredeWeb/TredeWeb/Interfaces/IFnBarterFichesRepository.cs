using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TredeWeb.DataLayer;

namespace TredeWeb.Interfaces
{
    public interface IFnBarterFichesRepository : IRepositoryBase<FnBarterFiches>
    {
        Task<IEnumerable<FnBarterFiches>> GetAllFnBarterFichesAsync();
        Task<FnBarterFiches> GetFnBarterFichesByIdAsync(int id);
        Task<FnBarterFiches> GetFnBarterFichesWithDetailsAsync(int id);
        void CreateFnBarterFiches(FnBarterFiches FnBarterFiches);
        void UpdateFnBarterFiches(FnBarterFiches FnBarterFiches);
        void DeleteFnBarterFiches(FnBarterFiches FnBarterFiches);
        Task Update(int id);

    }
}
