using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TredeWeb.DataLayer;

namespace TredeWeb.Interfaces
{
    public interface IDeparmentsRepository : IRepositoryBase<Departments>
    {

        Task<IEnumerable<Departments>> GetAllDeparmentsAsync();
        Task<Departments> GetDeparmentsByIdAsync(int id);
        Task<Departments> GetDeparmentsWithDetailsAsync(int id);
        void CreateDeparments(Departments Deparments);
        void UpdateDeparments(Departments Deparments);
        void DeleteDeparments(Departments Deparments);
        Task Update(int id);

    }
}
