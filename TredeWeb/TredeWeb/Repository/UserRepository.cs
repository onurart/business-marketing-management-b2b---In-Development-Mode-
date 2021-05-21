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
    public class UserRepository : RepositoryBase<Users>, IUserRepository
    {
        public UserRepository(TradeDbContext context)
      : base(context)
        {
        }
        public void CreateUser(Users User)
        {
            Create(User);
        }
        public void DeleteUser(Users User)
        {
            Delete(User);
        }
        public void UpdateUser(Users User)
        {
            Update(User);
        }




        public async Task<IEnumerable<Users>> GetAllUserAsync()
        {
            return await FindAll()
              .OrderBy(ow => ow.FirstName)
              .ToListAsync();
        }
        public async Task<Users> GetUserWithDetailsAsync(int id)
        {
            return await FindByCondition(ur => ur.Id.Equals(id))
                .FirstOrDefaultAsync();
        }
        public async Task<Users> GetUserByIdAsync(int id)
        {
            return await FindByCondition(st => st.Id.Equals(id))
            .Include(ac => ac.UserToRoles)
            .Include(ac => ac.Inventories)
            .Include(ac => ac.InventoryLines)
            .Include(ac => ac.InverseOwnerRefNavigation)
            .Include(ac => ac.Marks)
            .Include(ac => ac.Orders)
            .Include(ac => ac.PriceLists)
                     .FirstOrDefaultAsync();
        }
        public Task Update(int id)
        {
            throw new NotImplementedException();
        }

    }
}
