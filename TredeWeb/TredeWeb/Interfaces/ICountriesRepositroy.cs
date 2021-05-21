using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TredeWeb.DataLayer;

namespace TredeWeb.Interfaces
{
    public interface ICountriesRepositroy : IRepositoryBase<Countries>
    {
        Task<IEnumerable<Countries>> GetAllCCountriesAsync();
        Task<Countries> GetCountriesByIdAsync(int id);
        Task<Countries> GetCountriesWithDetailsAsync(int id);
        void CreateCountries(Countries countries);
        void UpdateCountries(Countries countries);
        void DeleteCountries(Countries countries);
        Task Update(int id);
    }
}
