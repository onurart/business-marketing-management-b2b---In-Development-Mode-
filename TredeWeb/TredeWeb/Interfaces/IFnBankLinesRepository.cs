using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TredeWeb.DataLayer;

namespace TredeWeb.Interfaces
{
    public interface IFnBankLinesRepository : IRepositoryBase<FnBankLines>
    {
        Task<IEnumerable<FnBankLines>> GetAllFnBankLinesAsync();
        Task<FnBankLines> GetFnBankLinesByIdAsync(int id);
        Task<FnBankLines> GetFnBankLinesWithDetailsAsync(int id);
        void CreateFnBankLines(FnBankLines fnBankLines);
        void UpdateFnBankLines(FnBankLines fnBankLines);
        void DeleteFnBankLines(FnBankLines fnBankLines);
        Task Update(int id);

    }
}
