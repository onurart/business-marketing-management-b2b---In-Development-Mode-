using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TredeWeb.DataLayer;

namespace TredeWeb.Interfaces
{
    public interface IMarksRepository : IRepositoryBase<Marks>
    {
        Task<IEnumerable<Marks>> GetAllMarksAsync();
        Task<Marks> GetMarksByIdAsync(int id);
        Task<Marks> GetMarksWithDetailsAsync(int id);
        void CreateMarks(Marks mark);
        void UpdateMarks(Marks mark);
        void DeleteMarks(Marks mark);
        Task Update(int id);


    }
}
