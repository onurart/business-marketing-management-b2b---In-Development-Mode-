using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TredeWeb.DataLayer;

namespace TredeWeb.Interfaces
{
    public interface IFnBarterLinesRepository : IRepositoryBase<FnBarterLines>
    {
        Task<IEnumerable<FnBarterLines>> GetAllFnBarterLinesAsync();
        Task<FnBarterLines> GetFnBarterLinesByIdAsync(int id);
        Task<FnBarterLines> GetFnBarteLinesWithDetailsAsync(int id);
        void CreateFnBarterLines(FnBarterLines fnBarterLines);
        void UpdateFnBarterLines(FnBarterLines fnBarterLines);
        void DeleteFnBarterLines(FnBarterLines fnBarterLines);
        Task Update(int id);
    }
}
