using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TredeWeb.DataLayer;
using TredeWeb.Interfaces;

namespace TredeWeb.Repository
{
    public class CountriesRepositroy : RepositoryBase<Countries>, ICountriesRepositroy
    {
        public CountriesRepositroy(TradeDbContext context)
       : base(context)
        {
        }

        public void CreateCountries(Countries countries)
        {
            CreateCountries(countries);
        }
        public void DeleteCountries(Countries countries)
        {
            DeleteCountries(countries);
        }

        public async Task<IEnumerable<Countries>> GetAllCCountriesAsync()
        {
            return await FindAll()
               .OrderBy(ow => ow.Id)
               .ToListAsync();
        }

        public async Task<Countries> GetCountriesByIdAsync(int id)
        {
            return await FindByCondition(ac => ac.Id.Equals(id))
               .FirstOrDefaultAsync();
        }

        public async Task<Countries> GetCountriesWithDetailsAsync(int id)
        {
            return await FindByCondition(ac => ac.Id.Equals(id))
                                .Include(ac => ac.Addresses)
                               .FirstOrDefaultAsync();
        }

        public async Task Update(int id)
        {
            await context.SaveChangesAsync();
        }

        public void UpdateCountries(Countries countries)
        {
            UpdateCountries(countries);
        }
    }
}
