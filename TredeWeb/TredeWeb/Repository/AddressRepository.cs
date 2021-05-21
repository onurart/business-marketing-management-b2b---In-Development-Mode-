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
    public class AddressRepository : RepositoryBase<Addresses>, IAddressRepository
    {
        public AddressRepository(TradeDbContext context)
       : base(context)
        {
        }

        public void CreateAddresses(Addresses addresses)
        {
            CreateAddresses(addresses);
        }

        public void DeleteAddresses(Addresses addresses)
        {
            DeleteAddresses(addresses);
        }



        public async Task<Addresses> GetAddressesByIdAsync(int id)
        {
            return await FindByCondition(ac => ac.Id.Equals(id))
               .FirstOrDefaultAsync();
        }

        public async Task<Addresses> GetAddressesWithDetailsAsync(int id)
        {
            return await FindByCondition(st => st.Id.Equals(id))
             .Include(ac => ac.Users)
                                   .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Addresses>> GetAllAAddressesAsync()
        {       
            return await FindAll()
               .OrderBy(ow => ow.Id)
               .ToListAsync();
        }

        public async Task Update(int id)
        {
            await context.SaveChangesAsync();
        }

        public void UpdateAddresses(Addresses addresses)
        {
            UpdateAddresses(addresses);
        }
    }
}
