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
    public class CitiesRepository : RepositoryBase<Cities>, ICitiesRepository
    {
        public CitiesRepository(TradeDbContext context)
       : base(context)
        {
        }

        public void CreateCities(Cities cities)
        {
            CreateCities(cities);
        }
        public void DeleteCities(Cities cities)
        {
            DeleteCities(cities);
        }
        public void UpdateCities(Cities cities)
        {
            UpdateCities(cities);
        }




        public async Task<Cities> GetCitiesByIdAsync(int id)
        {
            return await FindByCondition(ac => ac.Id.Equals(id))
              .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Cities>> GetAllCitiesAsync()
        {
            return await FindAll()
               .OrderBy(ow => ow.Id)
               .ToListAsync();
        }

        public async Task<Cities> GetCitiesWithDetailsAsync(int id)
        {
            return  await FindByCondition(ac => ac.Id.Equals(id))
                               .Include(ac => ac.Addresses)                            
                 .FirstOrDefaultAsync();
        }

        public async Task Update(int id)
        {
            await context.SaveChangesAsync();
        }

    }
}
