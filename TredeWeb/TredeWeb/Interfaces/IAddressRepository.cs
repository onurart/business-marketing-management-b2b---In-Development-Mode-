using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TredeWeb.DataLayer;

namespace TredeWeb.Interfaces
{
    public interface IAddressRepository : IRepositoryBase<Addresses>
    {
        Task<IEnumerable<Addresses>> GetAllAAddressesAsync();
        Task<Addresses> GetAddressesByIdAsync(int id);
        Task<Addresses> GetAddressesWithDetailsAsync(int id);
        void CreateAddresses(Addresses addresses);
        void UpdateAddresses(Addresses addresses);
        void DeleteAddresses(Addresses addresses);
        Task Update(int id);
    }

}

