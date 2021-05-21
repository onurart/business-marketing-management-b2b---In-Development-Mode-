using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TredeWeb.DataLayer;

namespace TredeWeb.Interfaces
{
    public interface IFnBankFichesRepository : IRepositoryBase<FnBankFiches>
    {
        Task<IEnumerable<FnBankFiches>> GetAllFnBankFichesAsync();
        Task<FnBankFiches> GetFnBankFichesByIdAsync(int id);
        Task<FnBankFiches> GetFnBankFichesWithDetailsAsync(int id);
        void CreateFnBankFiches(FnBankFiches fnBankFiches);
        void UpdateFnBankFiches(FnBankFiches fnBankFiches);
        void DeleteFnBankFiches(FnBankFiches fnBankFiches);
        Task Update(int id);
    }
}
