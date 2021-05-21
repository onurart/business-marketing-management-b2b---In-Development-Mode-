using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TredeWeb.DataLayer;

namespace TredeWeb.Interfaces
{
    public interface IFnCashFichesRepository : IRepositoryBase<FnCashFiches>
    {
        Task<IEnumerable<FnCashFiches>> GetAllFnCashFichesAsync();
        Task<FnCashFiches> GetFnCashFichesByIdAsync(int id);
        Task<FnCashFiches> GetFnCashFichestWithDetailsAsync(int id);
        void CreateFnCashFiches(FnCashFiches fnCashFiches);
        void UpdateFnCashFiches(FnCashFiches fnCashFiches);
        void DeleteFnCashFiches(FnCashFiches fnCashFiches);
        Task Update(int id);
    }
}
