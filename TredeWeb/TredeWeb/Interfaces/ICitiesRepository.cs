using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TredeWeb.DataLayer;

namespace TredeWeb.Interfaces
{
    public interface ICitiesRepository : IRepositoryBase<Cities>
    {
        Task<IEnumerable<Cities>> GetAllCitiesAsync();
    Task<Cities> GetCitiesByIdAsync(int id);
    Task<Cities> GetCitiesWithDetailsAsync(int id);
    void CreateCities(Cities cities);
    void UpdateCities(Cities cities);
    void DeleteCities(Cities cities);
    Task Update(int id);
}
}
