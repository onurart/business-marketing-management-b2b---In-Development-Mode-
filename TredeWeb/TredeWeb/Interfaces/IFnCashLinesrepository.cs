using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TredeWeb.DataLayer;

namespace TredeWeb.Interfaces
{
    public interface IFnCashLinesrepository : IRepositoryBase<FnCashLines>
    {
        Task<IEnumerable<FnCashLines>> GetAllFnCashLinesAsync();
        Task<FnCashLines> GetFnCashLinesByIdAsync(int id);
        Task<FnCashLines> GetFnCashLinesWithDetailsAsync(int id);
        void CreateFnCashLines(FnCashLines fnCashLines);
        void UpdateFnCashLines(FnCashLines fnCashLines);
        void DeleteFnCashLines(FnCashLines fnCashLines);
        Task Update(int id);

    }
}
